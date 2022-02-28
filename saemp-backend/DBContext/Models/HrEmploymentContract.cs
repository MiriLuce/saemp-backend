using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("hrEmploymentContract")]
    public partial class HrEmploymentContract
    {
        [Key]
        [Column("idEmploymentContract")]
        public long IdEmploymentContract { get; set; }
        [Column("idEmployee")]
        public long IdEmployee { get; set; }
        [Column("idJobTitle")]
        public int IdJobTitle { get; set; }
        [Column("salary", TypeName = "decimal(4, 2)")]
        public decimal? Salary { get; set; }
        [Column("isPerHour")]
        public bool IsPerHour { get; set; }
        [Column("admissionDate", TypeName = "datetime")]
        public DateTime AdmissionDate { get; set; }
        [Column("cessationDate", TypeName = "datetime")]
        public DateTime CessationDate { get; set; }

        [ForeignKey(nameof(IdEmployee))]
        [InverseProperty(nameof(HrEmployee.HrEmploymentContracts))]
        public virtual HrEmployee IdEmployeeNavigation { get; set; }
        [ForeignKey(nameof(IdJobTitle))]
        [InverseProperty(nameof(HrJobTitle.HrEmploymentContracts))]
        public virtual HrJobTitle IdJobTitleNavigation { get; set; }
    }
}
