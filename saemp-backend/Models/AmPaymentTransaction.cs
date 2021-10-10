using System;
using System.Collections.Generic;

#nullable disable

namespace saemp_backend.Models
{
    public partial class AmPaymentTransaction
    {
        public long IdPaymentTransaction { get; set; }
        public short IdPaymentMethod { get; set; }
        public long IdEmployee { get; set; }
        public string NumberTransaction { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual HrEmployee IdEmployeeNavigation { get; set; }
        public virtual AmPaymentMethod IdPaymentMethodNavigation { get; set; }
        public virtual AmPaymentTransactionDetail AmPaymentTransactionDetail { get; set; }
    }
}
