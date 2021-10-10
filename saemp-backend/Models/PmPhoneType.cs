using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class PmPhoneType
    {
        public PmPhoneType()
        {
            PmPhones = new HashSet<PmPhone>();
        }

        public short IdPhoneType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PmPhone> PmPhones { get; set; }
    }
}
