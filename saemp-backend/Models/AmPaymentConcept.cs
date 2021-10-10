using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class AmPaymentConcept
    {
        public AmPaymentConcept()
        {
            AmSchoolYearPayments = new HashSet<AmSchoolYearPayment>();
        }

        public short IdPaymentConcept { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AmSchoolYearPayment> AmSchoolYearPayments { get; set; }
    }
}
