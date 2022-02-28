using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("amPaymentConcept")]
    public partial class AmPaymentConcept
    {
        public AmPaymentConcept()
        {
            AmSchoolYearPayments = new HashSet<AmSchoolYearPayment>();
        }

        [Key]
        [Column("idPaymentConcept")]
        public short IdPaymentConcept { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; }

        [InverseProperty(nameof(AmSchoolYearPayment.IdPaymentConceptNavigation))]
        public virtual ICollection<AmSchoolYearPayment> AmSchoolYearPayments { get; set; }
    }
}
