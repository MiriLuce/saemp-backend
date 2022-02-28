using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("amSchoolYearPayment")]
    public partial class AmSchoolYearPayment
    {
        public AmSchoolYearPayment()
        {
            AmStudentInstallments = new HashSet<AmStudentInstallment>();
        }

        [Key]
        [Column("idSchoolYearPayment")]
        public long IdSchoolYearPayment { get; set; }
        [Column("idSchoolYearLevel")]
        public long IdSchoolYearLevel { get; set; }
        [Column("idPaymentConcept")]
        public short IdPaymentConcept { get; set; }
        [Column("amount", TypeName = "decimal(4, 2)")]
        public decimal Amount { get; set; }
        [Column("quantity")]
        public short Quantity { get; set; }

        [ForeignKey(nameof(IdPaymentConcept))]
        [InverseProperty(nameof(AmPaymentConcept.AmSchoolYearPayments))]
        public virtual AmPaymentConcept IdPaymentConceptNavigation { get; set; }
        [ForeignKey(nameof(IdSchoolYearLevel))]
        [InverseProperty(nameof(EmSchoolYearLevel.AmSchoolYearPayments))]
        public virtual EmSchoolYearLevel IdSchoolYearLevelNavigation { get; set; }
        [InverseProperty(nameof(AmStudentInstallment.IdSchoolYearPaymentNavigation))]
        public virtual ICollection<AmStudentInstallment> AmStudentInstallments { get; set; }
    }
}
