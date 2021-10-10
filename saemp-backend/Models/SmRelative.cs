using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class SmRelative
    {
        public long IdRelative { get; set; }
        public string IdStudent { get; set; }
        public int IdRelationship { get; set; }
        public bool LiveWithStudent { get; set; }
        public bool IsGuardian { get; set; }

        public virtual SmRelationship IdRelationshipNavigation { get; set; }
        public virtual PmPerson IdRelativeNavigation { get; set; }
        public virtual SmStudent IdStudentNavigation { get; set; }
    }
}
