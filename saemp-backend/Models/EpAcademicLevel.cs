using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class EpAcademicLevel
    {
        public EpAcademicLevel()
        {
            EmSchoolYears = new HashSet<EmSchoolYear>();
            EpSchoolLevels = new HashSet<EpSchoolLevel>();
        }

        public short IdAcademicLevel { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<EmSchoolYear> EmSchoolYears { get; set; }
        public virtual ICollection<EpSchoolLevel> EpSchoolLevels { get; set; }
    }
}
