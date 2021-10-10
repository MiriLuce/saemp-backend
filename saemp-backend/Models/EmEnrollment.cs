using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class EmEnrollment
    {
        public EmEnrollment()
        {
            AmBinnaclePayments = new HashSet<AmBinnaclePayment>();
            AmStudentInstallments = new HashSet<AmStudentInstallment>();
        }

        public long IdEnrollment { get; set; }
        public long IdEmployee { get; set; }
        public string IdStudent { get; set; }
        public int? IdDiscountVersion { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string Description { get; set; }

        public virtual AmDiscountVersion IdDiscountVersionNavigation { get; set; }
        public virtual HrEmployee IdEmployeeNavigation { get; set; }
        public virtual SmStudent IdStudentNavigation { get; set; }
        public virtual ICollection<AmBinnaclePayment> AmBinnaclePayments { get; set; }
        public virtual ICollection<AmStudentInstallment> AmStudentInstallments { get; set; }
    }
}
