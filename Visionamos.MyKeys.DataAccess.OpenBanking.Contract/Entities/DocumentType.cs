using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visionamos.MyKeys.DataAccess.OpenBanking.Contract.Entities
{
    [Table("TBL_DOCUMENT_TYPE")]
    public class DocumentType
    {
        [Key]
        [Column("DCT_CODE"), StringLength(2)]
        public string Code { get; set; } //CC,CE,TI,NI

        [Column("DCT_DESCRIPTION"), StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<KeyCustomer> KeyCustomers { get; set; }
    }
}
