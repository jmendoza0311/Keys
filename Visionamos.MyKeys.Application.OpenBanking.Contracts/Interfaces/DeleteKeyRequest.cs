using System.ComponentModel.DataAnnotations;

namespace Visionamos.MyKeys.Application.OpenBanking.Contracts.Interfaces
{
    public class DeleteKeyRequest
    {
        // Identificación del cliente, puede ser un número de documento o un identificador único
        [Required, StringLength(4)]
        public required string ProcessKeyCustomer { get; set; }

        [Required, StringLength(16)]
        public required string ValueKeyCustomer { get; set; }
    }
}