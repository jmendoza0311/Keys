using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visionamos.MyKeys.DataAccess.OpenBanking.Contract.Entities
{
    [Table("TBL_KEY_CUSTOMER")]
    public class KeyCustomer
    {
        [Key]
        [Column("KCM_GGID")]
        public Guid Id { get; set; }

        [Required]
        [Column("KCM_DATE"), StringLength(8)]
        public string Date { get; set; }

        [Required]
        [Column("KCM_HOUR"), StringLength(6)]
        public string Hour { get; set; }

        [Required]
        [Column("KCM_SEQUENCE"), StringLength(16)]
        public string Sequence { get; set; }

        [Required]
        [Column("KCM_CHANNEL"), StringLength(10)]
        public string Channel { get; set; }

        [Required]
        [ForeignKey("KeyProcess")]
        [Column("KCM_PROCESS_KEY_CUSTOMER"), StringLength(4)]
        public string ProcessKeyCustomerCode { get; set; }
        public virtual KeyProcess KeyProcess { get; set; }

        [Required]
        [ForeignKey("KeyState")]
        [Column("KCM_KEY_STATE"), StringLength(2)]
        public string KeyStateCode { get; set; }
        public virtual KeyState KeyState { get; set; }

        [Required]
        [Column("KCM_TYPE_KEY_CUSTOMER"), StringLength(1)]
        public string TypeKeyCustomer { get; set; }
        [Required]
        [Column("KCM_VALUE_KEY_CUSTOMER"), StringLength(16)]
        public string ValueKeyCustomer { get; set; }
        [Required]
        [Column("KCM_SOURCE_ENTITY"), StringLength(10)]
        public string SourceEntity { get; set; }
        [Required]
        [Column("KCM_SOURCE_ACCOUNT_NUMBER"), StringLength(34)]
        public string SourceNumberAccount { get; set; }
        [Required]
        [ForeignKey("AccountType")]
        [Column("KCM_SOURCE_ACCOUNT_TYPE"), StringLength(2)]
        public string SourceAccountTypeCode { get; set; }
        public virtual AccountType AccountType { get; set; }
        [Required]
        [Column("KCM_SOURCE_TYPE_ACCOUNT_DESCRIPTION"), StringLength(100)]
        public string SourceTypeAccountDescription { get; set; }
        [Required]
        [Column("KCM_SOURCE_IDENTIFICATION"), StringLength(20)]
        public string SourceIdentification { get; set; }
        [Required]
        [ForeignKey("DocumentType")]
        [Column("KCM_SOURCE_TYPE_IDENTIFICATION"), StringLength(2)]
        public string SourceIdentificationTypeCode { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        [Required]
        [Column("KCM_FIRST_NAME"), StringLength(50)]
        public string FirstName { get; set; }
        
        [Column("KCM_SECOND_NAME"), StringLength(50)]
        public string SecondName { get; set; }
        [Required]
        [Column("KCM_SUR_NAME"), StringLength(50)]
        public string SurName { get; set; }

        [Column("KCM_SECOND_SUR_NAME"), StringLength(50)]
        public string SecondSurName { get; set; }
        [Required]
        [Column("KCM_USER"), StringLength(50)]
        public string User { get; set; }



    }
}
