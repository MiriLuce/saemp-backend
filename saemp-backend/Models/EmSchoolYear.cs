using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class EmSchoolYear
    {
        public EmSchoolYear()
        {
            EmSchoolYearLevels = new HashSet<EmSchoolYearLevel>();
        }

        public long IdSchoolYear { get; set; }
        public short IdAcademicLevel { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public short DueDay { get; set; }
        public int NewStudent { get; set; }
        public DateTime ClassStartDate { get; set; }

        public virtual EpAcademicLevel IdAcademicLevelNavigation { get; set; }
        public virtual ICollection<EmSchoolYearLevel> EmSchoolYearLevels { get; set; }
    }
}
