using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class SmRelationship
    {
        public SmRelationship()
        {
            SmRelatives = new HashSet<SmRelative>();
        }

        public int IdRelationship { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }

        public virtual ICollection<SmRelative> SmRelatives { get; set; }
    }
}
