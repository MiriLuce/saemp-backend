using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class PmDistrict
    {
        public PmDistrict()
        {
            PmPeople = new HashSet<PmPerson>();
        }

        public int IdDistrict { get; set; }
        public int IdDepartment { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }

        public virtual PmDepartment IdDepartmentNavigation { get; set; }
        public virtual ICollection<PmPerson> PmPeople { get; set; }
    }
}
