using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visionamos.MyKeys.DataAccess.OpenBanking.Contract.Entities
{
    [Table("TBL_KEY_STATE")]
    public class KeyState
    {
        [Key]
        [Column("KST_CODE"), StringLength(2)]
        public string Code { get; set; }

        [Column("KST_DESCRIPTION"), StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<KeyCustomer> KeyCustomers { get; set; }
    }
}