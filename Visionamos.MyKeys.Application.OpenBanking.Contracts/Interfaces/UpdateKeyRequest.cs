using System.ComponentModel.DataAnnotations;

namespace Visionamos.MyKeys.Application.OpenBanking.Contracts.Interfaces
{
    public class UpdateKeyRequest
    {
        [StringLength(20)]
        public  string ValueKeyCustomer { get; set; } // Identificador único de la llave del cliente

        [StringLength(15)]
        public  string Identification { get; set; } // Cambiado de ValueKeyCustomer a Identification

        [StringLength(20)]
        public  string SourceNumberAccount { get; set; } // Número de cuenta

        [StringLength(2)]
        public  string SourceTypeAccount { get; set; } // Tipo de cuenta

        [StringLength(4)]
        public  string KeyState { get; set; } // Estado de la llave

        [StringLength(50)]
        public  string FirstName { get; set; } // Primer nombre del cliente

        [StringLength(4)]
        public  string ProcessKeyCustomer { get; set; } // Proceso de la llave del cliente
    }
}