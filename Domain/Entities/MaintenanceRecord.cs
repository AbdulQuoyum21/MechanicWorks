using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic.Domain.Entities
{
    public class MaintenanceRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public MaintenanceType Category { get; set; }

        public DateTime? DischargeDate { get; set; }

        [Required]
        public int MaintenanceLocationId { get; set; }

        [Required]
        public RepairStatus Status { get; set; }

        [Required]
        public int AttendantId { get; set; }

        public int? InvoiceId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MaintenanceCost { get; set; }

        public MaintenancePart Part { get; set; }

        [Required]
        public string Fault { get; set; }

        //Navigation properties (optional, depending on your models)
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public Staff Attendant { get; set; }
        public Invoice Invoice { get; set; }
    }
}
