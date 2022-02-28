using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("amBinnaclePayment")]
    public partial class AmBinnaclePayment
    {
        [Key]
        [Column("idBinnaclePayment")]
        public long IdBinnaclePayment { get; set; }
        [Column("idEnrollment")]
        public long IdEnrollment { get; set; }
        [Column("idEmployee")]
        public long IdEmployee { get; set; }
        [Column("registrationDate", TypeName = "datetime")]
        public DateTime RegistrationDate { get; set; }
        [Required]
        [Column("description", TypeName = "text")]
        public string Description { get; set; }

        [ForeignKey(nameof(IdEmployee))]
        [InverseProperty(nameof(HrEmployee.AmBinnaclePayments))]
        public virtual HrEmployee IdEmployeeNavigation { get; set; }
        [ForeignKey(nameof(IdEnrollment))]
        [InverseProperty(nameof(EmEnrollment.AmBinnaclePayments))]
        public virtual EmEnrollment IdEnrollmentNavigation { get; set; }
    }
}
