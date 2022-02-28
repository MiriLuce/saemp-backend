using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("epSchoolLevel")]
    public partial class EpSchoolLevel
    {
        public EpSchoolLevel()
        {
            EmSchoolYearLevels = new HashSet<EmSchoolYearLevel>();
            SmStudentSchoolOrigins = new HashSet<SmStudentSchoolOrigin>();
        }

        [Key]
        [Column("idSchoolLevel")]
        public short IdSchoolLevel { get; set; }
        [Column("idAcademicLevel")]
        public short IdAcademicLevel { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("abbreviation")]
        [StringLength(10)]
        public string Abbreviation { get; set; }

        [ForeignKey(nameof(IdAcademicLevel))]
        [InverseProperty(nameof(EpAcademicLevel.EpSchoolLevels))]
        public virtual EpAcademicLevel IdAcademicLevelNavigation { get; set; }
        [InverseProperty(nameof(EmSchoolYearLevel.IdSchoolLevelNavigation))]
        public virtual ICollection<EmSchoolYearLevel> EmSchoolYearLevels { get; set; }
        [InverseProperty(nameof(SmStudentSchoolOrigin.IdSchoolLevelNavigation))]
        public virtual ICollection<SmStudentSchoolOrigin> SmStudentSchoolOrigins { get; set; }
    }
}
