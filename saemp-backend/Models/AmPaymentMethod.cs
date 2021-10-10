using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class AmPaymentMethod
    {
        public AmPaymentMethod()
        {
            AmPaymentTransactions = new HashSet<AmPaymentTransaction>();
        }

        public short IdPaymentMethod { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<AmPaymentTransaction> AmPaymentTransactions { get; set; }
    }
}
