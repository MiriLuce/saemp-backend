using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class PmDepartment
    {
        public PmDepartment()
        {
            EpSchoolOrigins = new HashSet<EpSchoolOrigin>();
            PmDistricts = new HashSet<PmDistrict>();
            PmPeople = new HashSet<PmPerson>();
        }

        public int IdDepartment { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }

        public virtual ICollection<EpSchoolOrigin> EpSchoolOrigins { get; set; }
        public virtual ICollection<PmDistrict> PmDistricts { get; set; }
        public virtual ICollection<PmPerson> PmPeople { get; set; }
    }
}
