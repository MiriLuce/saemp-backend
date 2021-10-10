using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class AmPaymentStatus
    {
        public AmPaymentStatus()
        {
            AmStudentInstallments = new HashSet<AmStudentInstallment>();
        }

        public short IdPaymentStatus { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<AmStudentInstallment> AmStudentInstallments { get; set; }
    }
}
