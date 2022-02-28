using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("hrJobTitle")]
    public partial class HrJobTitle
    {
        public HrJobTitle()
        {
            HrEmploymentContracts = new HashSet<HrEmploymentContract>();
        }

        [Key]
        [Column("idJobTitle")]
        public int IdJobTitle { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("abbreviation")]
        [StringLength(10)]
        public string Abbreviation { get; set; }
        [Column("isActive")]
        public bool IsActive { get; set; }

        [InverseProperty(nameof(HrEmploymentContract.IdJobTitleNavigation))]
        public virtual ICollection<HrEmploymentContract> HrEmploymentContracts { get; set; }
    }
}
