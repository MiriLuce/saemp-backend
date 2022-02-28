using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("smStudentSchoolOrigin")]
    public partial class SmStudentSchoolOrigin
    {
        [Key]
        [Column("idStudentSchoolOrigin")]
        public long IdStudentSchoolOrigin { get; set; }
        [Column("idSchoolOrigin")]
        public long IdSchoolOrigin { get; set; }
        [Required]
        [Column("idStudent")]
        [StringLength(8)]
        public string IdStudent { get; set; }
        [Column("idSchoolLevel")]
        public short IdSchoolLevel { get; set; }
        [Column("idScholarStatus")]
        public short IdScholarStatus { get; set; }
        [Column("observation")]
        [StringLength(200)]
        public string Observation { get; set; }

        [ForeignKey(nameof(IdScholarStatus))]
        [InverseProperty(nameof(EpScholarStatus.SmStudentSchoolOrigins))]
        public virtual EpScholarStatus IdScholarStatusNavigation { get; set; }
        [ForeignKey(nameof(IdSchoolLevel))]
        [InverseProperty(nameof(EpSchoolLevel.SmStudentSchoolOrigins))]
        public virtual EpSchoolLevel IdSchoolLevelNavigation { get; set; }
        [ForeignKey(nameof(IdSchoolOrigin))]
        [InverseProperty(nameof(EpSchoolOrigin.SmStudentSchoolOrigins))]
        public virtual EpSchoolOrigin IdSchoolOriginNavigation { get; set; }
        [ForeignKey(nameof(IdStudent))]
        [InverseProperty(nameof(SmStudent.SmStudentSchoolOrigins))]
        public virtual SmStudent IdStudentNavigation { get; set; }
    }
}
