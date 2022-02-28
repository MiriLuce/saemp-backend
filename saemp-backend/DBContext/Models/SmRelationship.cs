using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("smRelationship")]
    public partial class SmRelationship
    {
        public SmRelationship()
        {
            SmRelatives = new HashSet<SmRelative>();
        }

        [Key]
        [Column("idRelationship")]
        public int IdRelationship { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("isDefault")]
        public bool IsDefault { get; set; }

        [InverseProperty(nameof(SmRelative.IdRelationshipNavigation))]
        public virtual ICollection<SmRelative> SmRelatives { get; set; }
    }
}
