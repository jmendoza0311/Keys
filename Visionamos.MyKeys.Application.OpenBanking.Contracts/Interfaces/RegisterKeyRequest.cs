using System.ComponentModel.DataAnnotations;

namespace Visionamos.MyKeys.Application.OpenBanking.Contracts.Interfaces
{
    public class RegisterKeyRequest 
    {
        [Required, StringLength(8), RegularExpression(@"^\d{8}$")]
        public required string Date { get; set; }

        [Required, StringLength(6), RegularExpression(@"^\d{6}$")]
        public required string Hour { get; set; }

        [Required, StringLength(16), RegularExpression(@"^\d{16}$")]
        public required string Sequence { get; set; }

        [Required, StringLength(10)]
        public required string Channel { get; set; }

        [Required, StringLength(4)]
        public required string ProcessKeyCustomer { get; set; }

        [Required, StringLength(1)]
        public required string TypeKeyCustomer { get; set; }

        [Required, StringLength(16)]
        public required string ValueKeyCustomer { get; set; }

        [Required, StringLength(8)]
        public required string SourceEntity { get; set; }

        [Required, StringLength(20)]
        public required string SourceNumberAccount { get; set; }

        [Required, StringLength(2)]
        public required string SourceTypeAccount { get; set; }

        [Required, StringLength(100)]
        public required string SourceTypeAccountDescription { get; set; }

        [Required, StringLength(15)]
        public required string SourceIdentification { get; set; }

        [Required, StringLength(2)]
        public required string SourceTypeIdentification { get; set; }

        [Required, StringLength(50)]
        public required string FirstName { get; set; }

        [StringLength(50)]
        public string? SecondName { get; set; }

        [Required, StringLength(50)]
        public required string SurName { get; set; }

        [StringLength(50)]
        public string? SecondSurName { get; set; }

        [Required, StringLength(50)]
        public required string User { get; set; }
    }
}