using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class EpSchoolLevel
    {
        public EpSchoolLevel()
        {
            EmSchoolYearLevels = new HashSet<EmSchoolYearLevel>();
            SmStudentSchoolOrigins = new HashSet<SmStudentSchoolOrigin>();
        }

        public short IdSchoolLevel { get; set; }
        public short IdAcademicLevel { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual EpAcademicLevel IdAcademicLevelNavigation { get; set; }
        public virtual ICollection<EmSchoolYearLevel> EmSchoolYearLevels { get; set; }
        public virtual ICollection<SmStudentSchoolOrigin> SmStudentSchoolOrigins { get; set; }
    }
}
