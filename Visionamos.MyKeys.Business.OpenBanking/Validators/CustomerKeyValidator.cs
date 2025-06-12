using Visionamos.MyKeys.Business.OpenBanking.Constants;
using Visionamos.MyKeys.DataAccess.OpenBanking.Contract.Entities;

namespace Visionamos.MyKeys.Business.OpenBanking.Validators
{
    public class CustomerKeyValidator
    {
        private static readonly HashSet<string> ValidProcesses = new() { "NEWR", "AMND", "DEAC" };
        private static readonly HashSet<string> ValidAccountTypes = new() { "AH", "CR", "DE", "AV" };
        private static readonly HashSet<string> ValidDocumentTypes = new() { "CC", "CE", "TI", "NI" };

        public static bool IsValidProcess(string process) => ValidProcesses.Contains(process);
        public static bool IsValidAccountType(string type) => ValidAccountTypes.Contains(type);
        public static bool IsValidDocumentType(string type) => ValidDocumentTypes.Contains(type);

        public static void ValidateFieldsForUpdate(KeyCustomer model)
        {
            if (model.ProcessKeyCustomerCode != KeyProcesses.AMND)
                return;

            var hasChanges = !string.IsNullOrWhiteSpace(model.FirstName) ||
                             !string.IsNullOrWhiteSpace(model.SourceNumberAccount) ||
                             !string.IsNullOrWhiteSpace(model.SourceAccountTypeCode);
            if (!hasChanges)
                throw new KeyValidationException("Debe modificar al menos un campo para actualizar (nombre, cuenta o tipo cuenta).");
        }
    }
}