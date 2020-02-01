using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZonerDonor.Core.Models
{
    public class Fundraiser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal CurrentTotal { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
