using Mechanic.Domain.Common;
using Mechanic.Domain.Enums;

namespace Mechanic.Domain.Entities
{
    public class PartVehicle : BaseClass
    {
        public MaintenancePart PartId { get; set; }
        public long VehicleId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public long MaintenanceRecordId { get; set; }
        public virtual MaintenanceRecord {get; set; }
}
