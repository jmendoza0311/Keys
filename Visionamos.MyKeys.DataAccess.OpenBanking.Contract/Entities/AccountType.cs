using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visionamos.MyKeys.DataAccess.OpenBanking.Contract.Entities
{
    [Table("TBL_ACCOUNT_TYPE")]
    public class AccountType
    {
        [Key]
        [Column("ACT_CODE"), StringLength(2)]
        public string Code { get; set; } //AH,CR,DE,AV

        [Column("ACT_DESCRIPTION"), StringLength(100)]
        public string Description { get; set; }
        public virtual ICollection<KeyCustomer> KeyCustomers { get; set; }

    }
}
