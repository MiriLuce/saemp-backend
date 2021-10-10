using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class AmDiscountVersion
    {
        public AmDiscountVersion()
        {
            AmStudentInstallments = new HashSet<AmStudentInstallment>();
            EmEnrollments = new HashSet<EmEnrollment>();
        }

        public int IdDiscountVersion { get; set; }
        public int IdDiscount { get; set; }
        public string Name { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public bool IsRate { get; set; }

        public virtual AmDiscount IdDiscountNavigation { get; set; }
        public virtual ICollection<AmStudentInstallment> AmStudentInstallments { get; set; }
        public virtual ICollection<EmEnrollment> EmEnrollments { get; set; }
    }
}
