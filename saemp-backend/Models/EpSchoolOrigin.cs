using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class EpSchoolOrigin
    {
        public EpSchoolOrigin()
        {
            SmStudentSchoolOrigins = new HashSet<SmStudentSchoolOrigin>();
        }

        public long IdSchoolOrigin { get; set; }
        public int IdDepartment { get; set; }
        public int? IdDistrict { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }

        public virtual PmDepartment IdDepartmentNavigation { get; set; }
        public virtual ICollection<SmStudentSchoolOrigin> SmStudentSchoolOrigins { get; set; }
    }
}
