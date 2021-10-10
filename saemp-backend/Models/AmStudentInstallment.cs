using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class AmStudentInstallment
    {
        public AmStudentInstallment()
        {
            AmPaymentReceiptDetails = new HashSet<AmPaymentReceiptDetail>();
        }

        public long IdStudentInstallment { get; set; }
        public long IdEnrollment { get; set; }
        public long IdSchoolYearPayment { get; set; }
        public short IdPaymentStatus { get; set; }
        public int? IdDiscountVersion { get; set; }
        public decimal AmountSubTotal { get; set; }
        public decimal AmountDiscount { get; set; }
        public decimal AmountTotal { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountRemainder { get; set; }
        public DateTime TotalPaymentDate { get; set; }

        public virtual AmDiscountVersion IdDiscountVersionNavigation { get; set; }
        public virtual EmEnrollment IdEnrollmentNavigation { get; set; }
        public virtual AmPaymentStatus IdPaymentStatusNavigation { get; set; }
        public virtual AmSchoolYearPayment IdSchoolYearPaymentNavigation { get; set; }
        public virtual ICollection<AmPaymentReceiptDetail> AmPaymentReceiptDetails { get; set; }
    }
}
