using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class InRoom
    {
        public int IdRoom { get; set; }
        public int IdCampus { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public virtual InCampus IdCampusNavigation { get; set; }
    }
}
