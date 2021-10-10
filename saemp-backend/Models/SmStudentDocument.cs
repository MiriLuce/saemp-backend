using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class SmStudentDocument
    {
        public long IdStudentDocument { get; set; }
        public int IdStudentDocumentType { get; set; }
        public string IdStudent { get; set; }
        public long IdReceptionCoordinator { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public DateTime? EstimatedDate { get; set; }
        public string Description { get; set; }

        public virtual HrEmployee IdReceptionCoordinatorNavigation { get; set; }
        public virtual EpStudentDocumentType IdStudentDocumentTypeNavigation { get; set; }
        public virtual SmStudent IdStudentNavigation { get; set; }
    }
}
