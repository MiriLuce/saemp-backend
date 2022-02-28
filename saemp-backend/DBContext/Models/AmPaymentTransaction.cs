using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace saemp_backend.DBContext.Models
{
    [Table("amPaymentTransaction")]
    public partial class AmPaymentTransaction
    {
        [Key]
        [Column("idPaymentTransaction")]
        public long IdPaymentTransaction { get; set; }
        [Column("idPaymentMethod")]
        public short IdPaymentMethod { get; set; }
        [Column("idEmployee")]
        public long IdEmployee { get; set; }
        [Required]
        [Column("numberTransaction")]
        [StringLength(15)]
        public string NumberTransaction { get; set; }
        [Column("totalAmount", TypeName = "decimal(4, 2)")]
        public decimal TotalAmount { get; set; }
        [Column("paymentDate", TypeName = "datetime")]
        public DateTime PaymentDate { get; set; }
        [Column("registrationDate", TypeName = "datetime")]
        public DateTime RegistrationDate { get; set; }

        [ForeignKey(nameof(IdEmployee))]
        [InverseProperty(nameof(HrEmployee.AmPaymentTransactions))]
        public virtual HrEmployee IdEmployeeNavigation { get; set; }
        [ForeignKey(nameof(IdPaymentMethod))]
        [InverseProperty(nameof(AmPaymentMethod.AmPaymentTransactions))]
        public virtual AmPaymentMethod IdPaymentMethodNavigation { get; set; }
        [InverseProperty("IdPaymentTransactionNavigation")]
        public virtual AmPaymentTransactionDetail AmPaymentTransactionDetail { get; set; }
    }
}
