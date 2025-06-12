using System.Collections.Generic;

namespace Visionamos.MyKeys.Application.OpenBanking.Contracts.Interfaces
{
    public class KeyResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public  string StateCode { get; set; }
        public  string StateCodeVIS { get; set; }
        public  string StateDescriptionSystem { get; set; }
        public  string StateDescriptionCustomer { get; set; }
         public List<CustomerKeyDto> Keys { get; set; } = new();
    }
}