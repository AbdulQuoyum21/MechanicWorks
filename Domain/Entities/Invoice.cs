using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.Domain.Entities
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public int? MaintenanceRecordId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        public DateTime DateIssued { get; set; }

        public DateTime? DatePaid { get; set; }

        [Required]
        public InvoiceStatus Status { get; set; }

        public string PaymentMethod { get; set; }
    }
}
