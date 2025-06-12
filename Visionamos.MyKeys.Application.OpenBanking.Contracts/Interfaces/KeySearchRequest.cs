using System.ComponentModel.DataAnnotations;

namespace Visionamos.MyKeys.Application.OpenBanking.Contracts.Interfaces
{
    public class KeySearchRequest
    {
        [StringLength(15)]
        public string? Identification { get; set; }

        [StringLength(16)]
        public string? ValueKeyCustomer { get; set; }
        public string? SourceIdentification { get; set; }
    }
}