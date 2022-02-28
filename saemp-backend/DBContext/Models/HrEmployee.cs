using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("hrEmployee")]
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

        [Key]
        [Column("idEmployee")]
        public long IdEmployee { get; set; }
        [Column("userName")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Column("userPassword")]
        [StringLength(50)]
        public string UserPassword { get; set; }
        [Column("inactivityTime")]
        public short InactivityTime { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; }

        [ForeignKey(nameof(IdEmployee))]
        [InverseProperty(nameof(PmPerson.HrEmployee))]
        public virtual PmPerson IdEmployeeNavigation { get; set; }
        [InverseProperty(nameof(AmBinnaclePayment.IdEmployeeNavigation))]
        public virtual ICollection<AmBinnaclePayment> AmBinnaclePayments { get; set; }
        [InverseProperty(nameof(AmPaymentReceipt.IdEmployeeNavigation))]
        public virtual ICollection<AmPaymentReceipt> AmPaymentReceipts { get; set; }
        [InverseProperty(nameof(AmPaymentTransaction.IdEmployeeNavigation))]
        public virtual ICollection<AmPaymentTransaction> AmPaymentTransactions { get; set; }
        [InverseProperty(nameof(EmEnrollment.IdEmployeeNavigation))]
        public virtual ICollection<EmEnrollment> EmEnrollments { get; set; }
        [InverseProperty(nameof(HrEmploymentContract.IdEmployeeNavigation))]
        public virtual ICollection<HrEmploymentContract> HrEmploymentContracts { get; set; }
        [InverseProperty(nameof(SmStudentDocument.IdReceptionCoordinatorNavigation))]
        public virtual ICollection<SmStudentDocument> SmStudentDocuments { get; set; }
    }
}
