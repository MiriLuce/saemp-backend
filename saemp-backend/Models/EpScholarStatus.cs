using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class EpScholarStatus
    {
        public EpScholarStatus()
        {
            SmStudentSchoolOrigins = new HashSet<SmStudentSchoolOrigin>();
        }

        public short IdScholarStatus { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<SmStudentSchoolOrigin> SmStudentSchoolOrigins { get; set; }
    }
}
