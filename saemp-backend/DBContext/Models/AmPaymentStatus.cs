using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("amPaymentStatus")]
    public partial class AmPaymentStatus
    {
        public AmPaymentStatus()
        {
            AmStudentInstallments = new HashSet<AmStudentInstallment>();
        }

        [Key]
        [Column("idPaymentStatus")]
        public short IdPaymentStatus { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("abbreviation")]
        [StringLength(10)]
        public string Abbreviation { get; set; }

        [InverseProperty(nameof(AmStudentInstallment.IdPaymentStatusNavigation))]
        public virtual ICollection<AmStudentInstallment> AmStudentInstallments { get; set; }
    }
}
