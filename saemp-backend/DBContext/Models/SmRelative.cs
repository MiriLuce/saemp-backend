using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("smRelative")]
    public partial class SmRelative
    {
        [Key]
        [Column("idRelative")]
        public long IdRelative { get; set; }
        [Key]
        [Column("idStudent")]
        [StringLength(8)]
        public string IdStudent { get; set; }
        [Column("idRelationship")]
        public int IdRelationship { get; set; }
        [Column("liveWithStudent")]
        public bool LiveWithStudent { get; set; }
        [Column("isGuardian")]
        public bool IsGuardian { get; set; }

        [ForeignKey(nameof(IdRelationship))]
        [InverseProperty(nameof(SmRelationship.SmRelatives))]
        public virtual SmRelationship IdRelationshipNavigation { get; set; }
        [ForeignKey(nameof(IdRelative))]
        [InverseProperty(nameof(PmPerson.SmRelatives))]
        public virtual PmPerson IdRelativeNavigation { get; set; }
        [ForeignKey(nameof(IdStudent))]
        [InverseProperty(nameof(SmStudent.SmRelatives))]
        public virtual SmStudent IdStudentNavigation { get; set; }
    }
}
