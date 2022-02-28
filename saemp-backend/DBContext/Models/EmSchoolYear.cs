using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("emSchoolYear")]
    public partial class EmSchoolYear
    {
        public EmSchoolYear()
        {
            EmSchoolYearLevels = new HashSet<EmSchoolYearLevel>();
        }

        [Key]
        [Column("idSchoolYear")]
        public long IdSchoolYear { get; set; }
        [Column("idAcademicLevel")]
        public short IdAcademicLevel { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("year")]
        public int Year { get; set; }
        [Column("dueDay")]
        public short DueDay { get; set; }
        [Column("newStudent")]
        public int NewStudent { get; set; }
        [Column("classStartDate", TypeName = "date")]
        public DateTime ClassStartDate { get; set; }

        [ForeignKey(nameof(IdAcademicLevel))]
        [InverseProperty(nameof(EpAcademicLevel.EmSchoolYears))]
        public virtual EpAcademicLevel IdAcademicLevelNavigation { get; set; }
        [InverseProperty(nameof(EmSchoolYearLevel.IdSchoolYearNavigation))]
        public virtual ICollection<EmSchoolYearLevel> EmSchoolYearLevels { get; set; }
    }
}
