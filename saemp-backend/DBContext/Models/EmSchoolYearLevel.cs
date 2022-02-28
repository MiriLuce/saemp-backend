using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("emSchoolYearLevel")]
    public partial class EmSchoolYearLevel
    {
        public EmSchoolYearLevel()
        {
            AmSchoolYearPayments = new HashSet<AmSchoolYearPayment>();
        }

        [Key]
        [Column("idSchoolYearLevel")]
        public long IdSchoolYearLevel { get; set; }
        [Column("idSchoolYear")]
        public long IdSchoolYear { get; set; }
        [Column("idSchoolLevel")]
        public short IdSchoolLevel { get; set; }
        [Column("vacancyAmount")]
        public int VacancyAmount { get; set; }
        [Column("totalStudentEnrolledAmount")]
        public int TotalStudentEnrolledAmount { get; set; }
        [Column("newStudentEnrolledAmount")]
        public int NewStudentEnrolledAmount { get; set; }

        [ForeignKey(nameof(IdSchoolLevel))]
        [InverseProperty(nameof(EpSchoolLevel.EmSchoolYearLevels))]
        public virtual EpSchoolLevel IdSchoolLevelNavigation { get; set; }
        [ForeignKey(nameof(IdSchoolYear))]
        [InverseProperty(nameof(EmSchoolYear.EmSchoolYearLevels))]
        public virtual EmSchoolYear IdSchoolYearNavigation { get; set; }
        [InverseProperty(nameof(AmSchoolYearPayment.IdSchoolYearLevelNavigation))]
        public virtual ICollection<AmSchoolYearPayment> AmSchoolYearPayments { get; set; }
    }
}
