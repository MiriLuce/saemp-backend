using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class PmTypeDocumentIdentity
    {
        public PmTypeDocumentIdentity()
        {
            PmPeople = new HashSet<PmPerson>();
        }

        public int IdTypeDocumentIdentity { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public short Length { get; set; }
        public string LengthType { get; set; }
        public string NationalityType { get; set; }
        public string CharacterType { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PmPerson> PmPeople { get; set; }
    }
}
