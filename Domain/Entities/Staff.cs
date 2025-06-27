using Mechanic.Domain.Common;
using Mechanic.Domain.Enums;

namespace Mechanic.Domain.Entities
{
    public class Staff:BaseClass
    {
        public long ApplicationUserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
        public StaffType StaffType { get; set; }
    }

    public class Vehicle:BaseClass
    {
        public long CustomerId { get; set; }
        public string Brand { get; set; }
        public string? PlateNumber { get; set; }
        public string? Fault { get; set; }
        public FaultCategory FaultCategory { get; set; }
        public decimal OdometerBefore { get; set; }
        public decimal OdometerAfter { get; set; }
        public  VehicleStatus VehicleStatus { get; set; }
    }

    public class Customer : BaseClass
    {
        public string ApplicatonUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
   
}
