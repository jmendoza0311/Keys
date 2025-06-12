using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.MyKeys.Application.OpenBanking.Contracts.Interfaces;
using Visionamos.MyKeys.Business.OpenBanking.Constants;
using Visionamos.MyKeys.Business.OpenBanking.Interfaces;
using Visionamos.MyKeys.Business.OpenBanking.Validators;
using Visionamos.MyKeys.DataAccess.OpenBanking.Contract.Entities;
using Visionamos.MyKeys.DataAccess.OpenBanking.Repositories;

namespace Visionamos.MyKeys.Application.OpenBanking.Services
{
    public class ManageKeyService : IManageKeyService
    {
        private readonly ICustomerKeyRepository _repository;
        private readonly IKeyBusinessRules _rules;

        public ManageKeyService(ICustomerKeyRepository repository, IKeyBusinessRules rules)
        {
            _repository = repository;
            _rules = rules;
        }

        public async Task<KeyResponse> RegisterKeyAsync(RegisterKeyRequest request)
        {
            if (!_rules.IsValidProcess(request.ProcessKeyCustomer, KeyProcesses.NEWR))
                return Error("Proceso inválido: solo se permite 'NEWR' en registro.");

            if (!_rules.IsValidDate(request.Date) || !_rules.IsValidTime(request.Hour))
                return Error("Fecha u hora inválida.");

            if (!_rules.IsValidSequenceFormat(request.Sequence))
                return Error("La secuencia debe tener 16 dígitos numéricos.");

            if (!await _rules.IsSequenceUniqueAsync(request.Sequence))
                return Error("La secuencia ya fue utilizada.");

            if (!await _rules.IsValueKeyUniqueAsync(request.ValueKeyCustomer))
                return Error("La llave ya está registrada.");

            if (await _rules.ExceedsKeyLimitAsync(request.SourceIdentification))
                return Error("La cédula 10394400000 no puede tener más de 4 llaves activas.");

            if (!CustomerKeyValidator.IsValidAccountType(request.SourceTypeAccount))
                return Error("Tipo de cuenta inválido.");


            var entity = new KeyCustomer
            {
                Id = Guid.NewGuid(),
                Date = request.Date,
                Hour = request.Hour,
                Sequence = request.Sequence,
                Channel = request.Channel,
                ProcessKeyCustomerCode = request.ProcessKeyCustomer,
                TypeKeyCustomer = request.TypeKeyCustomer,
                ValueKeyCustomer = request.ValueKeyCustomer,
                SourceEntity = request.SourceEntity,
                SourceNumberAccount = request.SourceNumberAccount,
                SourceAccountTypeCode = request.SourceTypeAccount,
                SourceTypeAccountDescription = request.SourceTypeAccountDescription,
                SourceIdentification = request.SourceIdentification,
                SourceIdentificationTypeCode = request.SourceTypeIdentification,
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                SurName = request.SurName,
                SecondSurName = request.SecondSurName,
                User = request.User,
                KeyStateCode = KeyStates.ACTV
            };

            await _repository.CreateAsync(entity);
            return Success("Llave registrada exitosamente.");
        }

        public async Task<KeyResponse> DeleteKeyAsync(DeleteKeyRequest request)
        {
            if (!_rules.IsValidProcess(request.ProcessKeyCustomer, KeyProcesses.DEAC))
                return Error("Proceso inválido: solo se permite 'DEAC' para eliminar.");

            var key = await _repository.GetByValueKeyCustomerAsync(request.ValueKeyCustomer);
            if (key is null)
                return Error("La llave no existe.");

            if (key.KeyStateCode != KeyStates.ACTV)
                return Error($"Solo se pueden eliminar llaves en estado '{KeyStates.ACTV}'. Estado actual: '{key.KeyStateCode}'.");

            key.KeyStateCode = KeyStates.INTV;
            await _repository.UpdateAsync(key);

            return Success("Llave desactivada exitosamente.");
        }

        public async Task<KeyResponse> UpdateKeyAsync(UpdateKeyRequest request)
        {
            if (!_rules.IsValidProcess(request.ProcessKeyCustomer, KeyProcesses.AMND))
                return Error("Proceso inválido para actualización: se espera 'AMND'.");

            var key = await _repository.GetByValueKeyCustomerAsync(request.ValueKeyCustomer);
            if (key is null)
                return Error("La llave no existe.");

            key.FirstName = request.FirstName ?? key.FirstName;
            key.SourceNumberAccount = request.SourceNumberAccount ?? key.SourceNumberAccount;
            key.SourceAccountTypeCode = request.SourceTypeAccount ?? key.SourceAccountTypeCode;
            key.KeyStateCode = request.KeyState ?? key.KeyStateCode;

            CustomerKeyValidator.ValidateFieldsForUpdate(key);

            await _repository.UpdateAsync(key);

            var dto = new CustomerKeyDto
            {
                FirstName = key.FirstName,
                ValueKeyCustomer = key.ValueKeyCustomer,
                KeyState = key.KeyStateCode,
                AccountType = key.SourceAccountTypeCode,
                AccountNumber = key.SourceNumberAccount
            };

            return new KeyResponse { Success = true, 
                Message = "Llave actualizada exitosamente", 
                Keys = new List<CustomerKeyDto> { dto } 
            };
        }

        public async Task<KeyResponse> GetKeysByIdentificationAsync(GetKeyRequest request)
        {
            var keys = await _repository.GetByIdentificationAsync(request.SourceIdentification);
            if (keys == null || !keys.Any())
                return Error("No se encontraron llaves para la identificación dada.");

            var list = keys.Select(k => new CustomerKeyDto
            {
                ValueKeyCustomer = k.ValueKeyCustomer,
                AccountType = k.SourceAccountTypeCode,
                AccountNumber = k.SourceNumberAccount,
                KeyState = k.KeyStateCode
            }).ToList();

            return new KeyResponse { Success = true, Message = "Consulta exitosa.", Keys = list };
        }

        //public async Task<KeyResponse> SearchKeysAsync(KeySearchRequest request)
        //{
        //    var keys = await _repository.SearchAsync(request.SourceIdentification, request.ValueKeyCustomer);
        //    if (keys == null || !keys.Any())
        //        return Error("No se encontraron llaves con los criterios proporcionados.");

        //    var list = keys.Select(k => new CustomerKeyDto
        //    {
        //        ValueKeyCustomer = k.ValueKeyCustomer,
        //        AccountType = k.SourceAccountTypeCode,
        //        AccountNumber = k.SourceNumberAccount,
        //        KeyState = k.KeyStateCode
        //    }).ToList();

        //    return new KeyResponse { Success = true, Message = "Búsqueda exitosa.", Keys = list };
        //}

        private KeyResponse Error(string message) =>
            new KeyResponse { Success = false, Message = message };

        private KeyResponse Success(string message) =>
            new KeyResponse { Success = true, Message = message };
    }
}