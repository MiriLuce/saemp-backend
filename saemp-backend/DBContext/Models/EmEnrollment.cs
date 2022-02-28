using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("emEnrollment")]
    public partial class EmEnrollment
    {
        public EmEnrollment()
        {
            AmBinnaclePayments = new HashSet<AmBinnaclePayment>();
            AmStudentInstallments = new HashSet<AmStudentInstallment>();
        }

        [Key]
        [Column("idEnrollment")]
        public long IdEnrollment { get; set; }
        [Column("idEmployee")]
        public long IdEmployee { get; set; }
        [Required]
        [Column("idStudent")]
        [StringLength(8)]
        public string IdStudent { get; set; }
        [Column("idDiscountVersion")]
        public int? IdDiscountVersion { get; set; }
        [Column("enrollmentDate", TypeName = "datetime")]
        public DateTime EnrollmentDate { get; set; }
        [Column("startDate", TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column("admissionDate", TypeName = "datetime")]
        public DateTime AdmissionDate { get; set; }
        [Column("description")]
        [StringLength(250)]
        public string Description { get; set; }

        [ForeignKey(nameof(IdDiscountVersion))]
        [InverseProperty(nameof(AmDiscountVersion.EmEnrollments))]
        public virtual AmDiscountVersion IdDiscountVersionNavigation { get; set; }
        [ForeignKey(nameof(IdEmployee))]
        [InverseProperty(nameof(HrEmployee.EmEnrollments))]
        public virtual HrEmployee IdEmployeeNavigation { get; set; }
        [ForeignKey(nameof(IdStudent))]
        [InverseProperty(nameof(SmStudent.EmEnrollments))]
        public virtual SmStudent IdStudentNavigation { get; set; }
        [InverseProperty(nameof(AmBinnaclePayment.IdEnrollmentNavigation))]
        public virtual ICollection<AmBinnaclePayment> AmBinnaclePayments { get; set; }
        [InverseProperty(nameof(AmStudentInstallment.IdEnrollmentNavigation))]
        public virtual ICollection<AmStudentInstallment> AmStudentInstallments { get; set; }
    }
}
