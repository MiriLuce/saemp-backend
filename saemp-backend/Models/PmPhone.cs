using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class PmPhone
    {
        public long IdPhone { get; set; }
        public long IdPerson { get; set; }
        public short? IdPhoneCompany { get; set; }
        public short? IdPhoneType { get; set; }
        public string Number { get; set; }
        public bool IsForEmergency { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public virtual PmPerson IdPersonNavigation { get; set; }
        public virtual PmPhoneCompany IdPhoneCompanyNavigation { get; set; }
        public virtual PmPhoneType IdPhoneTypeNavigation { get; set; }
    }
}
