using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class AmSchoolYearPayment
    {
        public AmSchoolYearPayment()
        {
            AmStudentInstallments = new HashSet<AmStudentInstallment>();
        }

        public long IdSchoolYearPayment { get; set; }
        public long IdSchoolYearLevel { get; set; }
        public short IdPaymentConcept { get; set; }
        public decimal Amount { get; set; }
        public short Quantity { get; set; }

        public virtual AmPaymentConcept IdPaymentConceptNavigation { get; set; }
        public virtual EmSchoolYearLevel IdSchoolYearLevelNavigation { get; set; }
        public virtual ICollection<AmStudentInstallment> AmStudentInstallments { get; set; }
    }
}
