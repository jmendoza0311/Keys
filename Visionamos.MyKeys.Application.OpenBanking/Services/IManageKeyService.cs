using Visionamos.MyKeys.Application.OpenBanking.Contracts.Interfaces;

namespace Visionamos.MyKeys.Application.OpenBanking.Services
{
    public interface IManageKeyService
    {
        Task<KeyResponse> RegisterKeyAsync(RegisterKeyRequest request);
        Task<KeyResponse> UpdateKeyAsync(UpdateKeyRequest request);
        Task<KeyResponse> DeleteKeyAsync(DeleteKeyRequest request);
        Task<KeyResponse> GetKeysByIdentificationAsync(GetKeyRequest request);
        //Task<KeyResponse> SearchKeysAsync(KeySearchRequest request);
    }
}
