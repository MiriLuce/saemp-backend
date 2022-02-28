using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("smStudent")]
    public partial class SmStudent
    {
        public SmStudent()
        {
            EmEnrollments = new HashSet<EmEnrollment>();
            SmRelatives = new HashSet<SmRelative>();
            SmStudentDocuments = new HashSet<SmStudentDocument>();
            SmStudentSchoolOrigins = new HashSet<SmStudentSchoolOrigin>();
        }

        [Key]
        [Column("idStudent")]
        [StringLength(8)]
        public string IdStudent { get; set; }
        [Column("idPerson")]
        public long IdPerson { get; set; }
        [Column("allergies")]
        [StringLength(200)]
        public string Allergies { get; set; }
        [Column("disease")]
        [StringLength(250)]
        public string Disease { get; set; }
        [Column("otherHealthProblem")]
        [StringLength(250)]
        public string OtherHealthProblem { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; }

        [ForeignKey(nameof(IdPerson))]
        [InverseProperty(nameof(PmPerson.SmStudents))]
        public virtual PmPerson IdPersonNavigation { get; set; }
        [InverseProperty(nameof(EmEnrollment.IdStudentNavigation))]
        public virtual ICollection<EmEnrollment> EmEnrollments { get; set; }
        [InverseProperty(nameof(SmRelative.IdStudentNavigation))]
        public virtual ICollection<SmRelative> SmRelatives { get; set; }
        [InverseProperty(nameof(SmStudentDocument.IdStudentNavigation))]
        public virtual ICollection<SmStudentDocument> SmStudentDocuments { get; set; }
        [InverseProperty(nameof(SmStudentSchoolOrigin.IdStudentNavigation))]
        public virtual ICollection<SmStudentSchoolOrigin> SmStudentSchoolOrigins { get; set; }
    }
}
