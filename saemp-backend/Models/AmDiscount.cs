using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class AmDiscount
    {
        public AmDiscount()
        {
            AmDiscountVersions = new HashSet<AmDiscountVersion>();
        }

        public int IdDiscount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool NeedValidation { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AmDiscountVersion> AmDiscountVersions { get; set; }
    }
}
