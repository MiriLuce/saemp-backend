using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class HrJobTitle
    {
        public HrJobTitle()
        {
            HrEmploymentContracts = new HashSet<HrEmploymentContract>();
        }

        public int IdJobTitle { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<HrEmploymentContract> HrEmploymentContracts { get; set; }
    }
}
