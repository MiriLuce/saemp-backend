using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class HrEmployee
    {
        public HrEmployee()
        {
            AmBinnaclePayments = new HashSet<AmBinnaclePayment>();
            AmPaymentReceipts = new HashSet<AmPaymentReceipt>();
            AmPaymentTransactions = new HashSet<AmPaymentTransaction>();
            EmEnrollments = new HashSet<EmEnrollment>();
            HrEmploymentContracts = new HashSet<HrEmploymentContract>();
            SmStudentDocuments = new HashSet<SmStudentDocument>();
        }

        public long IdEmployee { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public short InactivityTime { get; set; }
        public bool IsActive { get; set; }

        public virtual PmPerson IdEmployeeNavigation { get; set; }
        public virtual ICollection<AmBinnaclePayment> AmBinnaclePayments { get; set; }
        public virtual ICollection<AmPaymentReceipt> AmPaymentReceipts { get; set; }
        public virtual ICollection<AmPaymentTransaction> AmPaymentTransactions { get; set; }
        public virtual ICollection<EmEnrollment> EmEnrollments { get; set; }
        public virtual ICollection<HrEmploymentContract> HrEmploymentContracts { get; set; }
        public virtual ICollection<SmStudentDocument> SmStudentDocuments { get; set; }
    }
}
