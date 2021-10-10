using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class InCampus
    {
        public InCampus()
        {
            AmPaymentReceipts = new HashSet<AmPaymentReceipt>();
            InRooms = new HashSet<InRoom>();
        }

        public int IdCampus { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Address { get; set; }
        public string AddressReference { get; set; }

        public virtual ICollection<AmPaymentReceipt> AmPaymentReceipts { get; set; }
        public virtual ICollection<InRoom> InRooms { get; set; }
    }
}
