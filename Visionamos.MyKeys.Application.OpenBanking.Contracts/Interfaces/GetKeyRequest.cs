using System.ComponentModel.DataAnnotations;
namespace Visionamos.MyKeys.Application.OpenBanking.Contracts.Interfaces
{   public class GetKeyRequest
    {
        [StringLength(20)]
        public string SourceIdentification { get; set; }
        [StringLength(16)]
        public string ValueKeyCustomer { get; set; } // Identificador único de la llave del cliente, opcional para búsquedas más específicas
    }
}