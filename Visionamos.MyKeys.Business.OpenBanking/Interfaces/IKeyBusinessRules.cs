using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Define la interfaz para las reglas de negocio que usará el servicio principal
namespace Visionamos.MyKeys.Business.OpenBanking.Interfaces
{
    public interface IKeyBusinessRules
    {
        bool IsValidProcess(string actual, string expected);
        bool IsValidSequenceFormat(string sequence);
        bool IsValidDate(string date);
        bool IsValidTime(string time);
        Task<bool> IsValueKeyUniqueAsync(string valueKey);
        Task<bool> IsSequenceUniqueAsync(string sequence);
        Task<bool> ExceedsKeyLimitAsync(string identification);
    }
}
