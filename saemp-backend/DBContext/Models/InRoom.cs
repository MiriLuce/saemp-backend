using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("inRoom")]
    public partial class InRoom
    {
        [Key]
        [Column("idRoom")]
        public int IdRoom { get; set; }
        [Column("idCampus")]
        public int IdCampus { get; set; }
        [Column("idInstitution")]
        public int IdInstitution { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("capacity")]
        public int Capacity { get; set; }

        [ForeignKey(nameof(IdCampus))]
        [InverseProperty(nameof(InCampus.InRooms))]
        public virtual InCampus IdCampusNavigation { get; set; }
    }
}
