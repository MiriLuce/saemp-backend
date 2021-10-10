using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class PmCountry
    {
        public PmCountry()
        {
            PmPeople = new HashSet<PmPerson>();
        }

        public int IdCountry { get; set; }
        public string Name { get; set; }
        public string LetterCode { get; set; }
        public string NumericCode { get; set; }
        public bool IsDefault { get; set; }

        public virtual ICollection<PmPerson> PmPeople { get; set; }
    }
}
