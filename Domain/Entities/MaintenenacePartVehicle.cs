using Mechanic.Domain.Common;
using Mechanic.Domain.Enums;

namespace Mechanic.Domain.Entities
{
    public class MaintenenacePartVehicle : BaseClass
    {
        public MaintenancePart PartId { get; set; }
        public long VehicleId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}