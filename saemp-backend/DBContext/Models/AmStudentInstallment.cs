using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("amStudentInstallment")]
    public partial class AmStudentInstallment
    {
        public AmStudentInstallment()
        {
            AmPaymentReceiptDetails = new HashSet<AmPaymentReceiptDetail>();
        }

        [Key]
        [Column("idStudentInstallment")]
        public long IdStudentInstallment { get; set; }
        [Column("idEnrollment")]
        public long IdEnrollment { get; set; }
        [Column("idSchoolYearPayment")]
        public long IdSchoolYearPayment { get; set; }
        [Column("idPaymentStatus")]
        public short IdPaymentStatus { get; set; }
        [Column("idDiscountVersion")]
        public int? IdDiscountVersion { get; set; }
        [Column("amountSubTotal", TypeName = "decimal(4, 2)")]
        public decimal AmountSubTotal { get; set; }
        [Column("amountDiscount", TypeName = "decimal(4, 2)")]
        public decimal AmountDiscount { get; set; }
        [Column("amountTotal", TypeName = "decimal(4, 2)")]
        public decimal AmountTotal { get; set; }
        [Column("amountPaid", TypeName = "decimal(4, 2)")]
        public decimal AmountPaid { get; set; }
        [Column("amountRemainder", TypeName = "decimal(4, 2)")]
        public decimal AmountRemainder { get; set; }
        [Column("totalPaymentDate", TypeName = "datetime")]
        public DateTime TotalPaymentDate { get; set; }

        [ForeignKey(nameof(IdDiscountVersion))]
        [InverseProperty(nameof(AmDiscountVersion.AmStudentInstallments))]
        public virtual AmDiscountVersion IdDiscountVersionNavigation { get; set; }
        [ForeignKey(nameof(IdEnrollment))]
        [InverseProperty(nameof(EmEnrollment.AmStudentInstallments))]
        public virtual EmEnrollment IdEnrollmentNavigation { get; set; }
        [ForeignKey(nameof(IdPaymentStatus))]
        [InverseProperty(nameof(AmPaymentStatus.AmStudentInstallments))]
        public virtual AmPaymentStatus IdPaymentStatusNavigation { get; set; }
        [ForeignKey(nameof(IdSchoolYearPayment))]
        [InverseProperty(nameof(AmSchoolYearPayment.AmStudentInstallments))]
        public virtual AmSchoolYearPayment IdSchoolYearPaymentNavigation { get; set; }
        [InverseProperty(nameof(AmPaymentReceiptDetail.IdStudentInstallmentNavigation))]
        public virtual ICollection<AmPaymentReceiptDetail> AmPaymentReceiptDetails { get; set; }
    }
}
