using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("amDiscountVersion")]
    public partial class AmDiscountVersion
    {
        public AmDiscountVersion()
        {
            AmStudentInstallments = new HashSet<AmStudentInstallment>();
            EmEnrollments = new HashSet<EmEnrollment>();
        }

        [Key]
        [Column("idDiscountVersion")]
        public int IdDiscountVersion { get; set; }
        [Column("idDiscount")]
        public int IdDiscount { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("discountAmount", TypeName = "decimal(4, 2)")]
        public decimal? DiscountAmount { get; set; }
        [Column("discountRate", TypeName = "decimal(4, 2)")]
        public decimal? DiscountRate { get; set; }
        [Column("startDate", TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column("finalDate", TypeName = "datetime")]
        public DateTime? FinalDate { get; set; }
        [Column("isRate")]
        public bool IsRate { get; set; }

        [ForeignKey(nameof(IdDiscount))]
        [InverseProperty(nameof(AmDiscount.AmDiscountVersions))]
        public virtual AmDiscount IdDiscountNavigation { get; set; }
        [InverseProperty(nameof(AmStudentInstallment.IdDiscountVersionNavigation))]
        public virtual ICollection<AmStudentInstallment> AmStudentInstallments { get; set; }
        [InverseProperty(nameof(EmEnrollment.IdDiscountVersionNavigation))]
        public virtual ICollection<EmEnrollment> EmEnrollments { get; set; }
    }
}
