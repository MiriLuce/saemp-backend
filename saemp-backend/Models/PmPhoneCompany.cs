using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class PmPhoneCompany
    {
        public PmPhoneCompany()
        {
            PmPhones = new HashSet<PmPhone>();
        }

        public short IdPhoneCompany { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PmPhone> PmPhones { get; set; }
    }
}
