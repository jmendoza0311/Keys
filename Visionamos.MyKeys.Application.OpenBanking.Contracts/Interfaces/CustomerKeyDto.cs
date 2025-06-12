using System;
using System.ComponentModel.DataAnnotations;

namespace Visionamos.MyKeys.Application.OpenBanking.Contracts.Interfaces
{
    public class CustomerKeyDto
    {
        [StringLength(8)]
        public string Date { get; set; }
        [StringLength(6)]
        public string Hour { get; set; }
        [StringLength(16)]
        public string Sequence { get; set; }
        [StringLength(10)]
        public string Channel { get; set; }
        [StringLength(10)]
        public string SourceEntity { get; set; }
        [StringLength(4)]
        public string ProcessKeyCustomer { get; set; }
        [StringLength(1)]
        public string TypeKeyCustomer { get; set; }
        [StringLength(16)]
        public string ValueKeyCustomer { get; set; }
        [StringLength(20)]
        public string SourceIdentification { get; set; }
        [StringLength(2)]
        public string SourceTypeIdentification { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string SecondName { get; set; }
        [StringLength(50)]
        public string SurName { get; set; }
        [StringLength(50)]
        public string SecondSurName { get; set; }
        [StringLength(34)]
        public string AccountNumber { get; set; }
        [StringLength(2)]
        public string AccountType { get; set; }
        [StringLength(100)]
        public string SourceTypeAccountDescription { get; set; }
        [StringLength(2)]
        public string KeyState { get; set; }
        [StringLength(50)]
        public string User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}