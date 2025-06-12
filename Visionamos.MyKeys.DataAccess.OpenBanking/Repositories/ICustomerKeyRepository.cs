using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Visionamos.MyKeys.DataAccess.OpenBanking.Contract.Entities;

namespace Visionamos.MyKeys.DataAccess.OpenBanking.Repositories
{
    public interface ICustomerKeyRepository
    {
        Task<IEnumerable<KeyCustomer>> GetAllAsync();
        Task<KeyCustomer> GetByIdAsync(Guid id);
        Task<KeyCustomer> GetByValueKeyCustomerAsync(string valueKeyCustomer);
        Task<IEnumerable<KeyCustomer>> GetBySourceIdentificationAsync(string sourceIdentification);
        Task<IEnumerable<KeyCustomer>> GetActiveKeysBySourceIdentificationAsync(string sourceIdentification);
        //Task<IEnumerable<KeyCustomer>> SearchKeysAsync(string? sourceIdentification = null, string? valueKeyCustomer = null);
        Task<KeyCustomer> CreateAsync(KeyCustomer keyCustomer);
        Task<KeyCustomer> UpdateAsync(KeyCustomer keyCustomer);
        Task<bool> DeactivateKeyAsync(string valueKeyCustomer);
        Task<bool> ValueKeyExistsAsync(string valueKeyCustomer);
        Task<bool> SequenceExistsAsync(string sequence);
        Task<int> GetActiveKeysCountByCustomerAsync(string sourceIdentification);
        Task<List<KeyCustomer>> GetByIdentificationAsync(string identification);
        //Task<List<KeyCustomer>> SearchAsync(string? identification, string? valueKeyCustomer);
    }
}