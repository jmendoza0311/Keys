using Visionamos.MyKeys.Business.OpenBanking.Interfaces;
using Visionamos.MyKeys.Business.OpenBanking.Validators;
using Visionamos.MyKeys.DataAccess.OpenBanking.Repositories;
//Contiene la implementación concreta de las reglas de negocio.
//Se inyecta el repositorio para verificar unicidad, contar llaves, etc.
namespace Visionamos.MyKeys.Business.OpenBanking.Rules
{
    public class KeyBusinessRules : IKeyBusinessRules
    {
        private readonly ICustomerKeyRepository _repository;

        public KeyBusinessRules(ICustomerKeyRepository repository)
        {
            _repository = repository;
        }
        public bool IsValidProcess(string actual, string expected) =>
           actual == expected;

        public bool IsValidSequenceFormat(string sequence) =>
            sequence.Length == 16 && sequence.All(char.IsDigit);

        public bool IsValidDate(string date) =>
            DateTime.TryParseExact(date, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out _);

        public bool IsValidTime(string time) => KeyValidators.IsValidTime(time);    

        public async Task<bool> IsValueKeyUniqueAsync(string valueKey) =>
           !await _repository.ValueKeyExistsAsync(valueKey);

        public async Task<bool> IsSequenceUniqueAsync(string sequence) =>
            !await _repository.SequenceExistsAsync(sequence);

        private const string SpecialIdentification = "10394400000";
        private const int MaxActiveKeys = 4;
        public async Task<bool> ExceedsKeyLimitAsync(string identification)
        {
            if (identification != SpecialIdentification)
                return false;

            var count = await _repository.GetActiveKeysCountByCustomerAsync(identification);
            return count >= MaxActiveKeys;
        }
    }
}
