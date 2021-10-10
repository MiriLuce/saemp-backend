using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class EpStudentDocumentType
    {
        public EpStudentDocumentType()
        {
            SmStudentDocuments = new HashSet<SmStudentDocument>();
        }

        public int IdStudentDocumentType { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool InEffect { get; set; }

        public virtual ICollection<SmStudentDocument> SmStudentDocuments { get; set; }
    }
}
