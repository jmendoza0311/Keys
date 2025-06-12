
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visionamos.MyKeys.DataAccess.OpenBanking.Contract.Entities
{
    [Table("TBL_KEY_PROCESS")]
    public class KeyProcess
    {
        [Key]
        [Column("KPR_CODE"), StringLength(4)]
        public string Code { get; set; } //NEWR, AMND, DEAC

        [Column("KPR_DESCRIPTION"), StringLength(100)]
        public string Description { get; set; } 
        public virtual ICollection<KeyCustomer> KeyCustomers { get; set; }
    }
}
