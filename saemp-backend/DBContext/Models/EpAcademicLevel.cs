using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("epAcademicLevel")]
    public partial class EpAcademicLevel
    {
        public EpAcademicLevel()
        {
            EmSchoolYears = new HashSet<EmSchoolYear>();
            EpSchoolLevels = new HashSet<EpSchoolLevel>();
        }

        [Key]
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

        [InverseProperty(nameof(EmSchoolYear.IdAcademicLevelNavigation))]
        public virtual ICollection<EmSchoolYear> EmSchoolYears { get; set; }
        [InverseProperty(nameof(EpSchoolLevel.IdAcademicLevelNavigation))]
        public virtual ICollection<EpSchoolLevel> EpSchoolLevels { get; set; }
    }
}
