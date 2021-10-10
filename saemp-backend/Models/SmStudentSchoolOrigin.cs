using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class SmStudentSchoolOrigin
    {
        public long IdStudentSchoolOrigin { get; set; }
        public long IdSchoolOrigin { get; set; }
        public string IdStudent { get; set; }
        public short IdSchoolLevel { get; set; }
        public short IdScholarStatus { get; set; }
        public string Observation { get; set; }

        public virtual EpScholarStatus IdScholarStatusNavigation { get; set; }
        public virtual EpSchoolLevel IdSchoolLevelNavigation { get; set; }
        public virtual EpSchoolOrigin IdSchoolOriginNavigation { get; set; }
        public virtual SmStudent IdStudentNavigation { get; set; }
    }
}
