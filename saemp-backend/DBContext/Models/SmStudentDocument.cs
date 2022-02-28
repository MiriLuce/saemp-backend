using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("smStudentDocument")]
    public partial class SmStudentDocument
    {
        [Key]
        [Column("idStudentDocument")]
        public long IdStudentDocument { get; set; }
        [Column("idStudentDocumentType")]
        public int IdStudentDocumentType { get; set; }
        [Required]
        [Column("idStudent")]
        [StringLength(8)]
        public string IdStudent { get; set; }
        [Column("idReceptionCoordinator")]
        public long IdReceptionCoordinator { get; set; }
        [Column("receptionDate", TypeName = "datetime")]
        public DateTime? ReceptionDate { get; set; }
        [Column("estimatedDate", TypeName = "datetime")]
        public DateTime? EstimatedDate { get; set; }
        [Column("description")]
        [StringLength(200)]
        public string Description { get; set; }

        [ForeignKey(nameof(IdReceptionCoordinator))]
        [InverseProperty(nameof(HrEmployee.SmStudentDocuments))]
        public virtual HrEmployee IdReceptionCoordinatorNavigation { get; set; }
        [ForeignKey(nameof(IdStudentDocumentType))]
        [InverseProperty(nameof(EpStudentDocumentType.SmStudentDocuments))]
        public virtual EpStudentDocumentType IdStudentDocumentTypeNavigation { get; set; }
        [ForeignKey(nameof(IdStudent))]
        [InverseProperty(nameof(SmStudent.SmStudentDocuments))]
        public virtual SmStudent IdStudentNavigation { get; set; }
    }
}
