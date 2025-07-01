using Mechanic.Domain.Common;
using Mechanic.Domain.Common.Utilities;
using Mechanic.Domain.Enums;

namespace Mechanic.Domain.Entities
{
    /// <summary>
    /// Represents a vehicle entity in the system. Ensure that when creating vehicles they are done via the constructor.
    /// </summary>
    public class Vehicle : BaseClass
    {
        public long CustomerId { get; set; }
        public string Brand { get; set; }
        /// <summary>
        /// The model of the vehicle, such as "Camry", "Civic", etc. This should not be empty
        /// </summary>
        public string Model { get; set; }
        public int ManufactureYear { get; set; }
        /// <summary>
        /// The vehicle's plate number, which can be empty if not applicable.
        /// </summary>
        public string PlateNumber { get; set; }
        /// <summary>
        /// Odometer reading before the vehicle was serviced or inspected. in KM
        /// </summary>
        public decimal OdometerBefore { get; set; } = 0.0m;
        /// <summary>
        /// Odometer reading after the vehicle was serviced or inspected. in KM
        /// </summary>
        public decimal OdometerAfter { get; set; } = 0.0m;
        public string GeneratedId { get; set; }
        /// <summary>
        /// Initial condition of the vehicle when it was added to the system.
        /// </summary>
        public VehicleCondition InitialCondition { get; set; }

        public virtual Customer Customer { get; set; }
        public string GenerateId()
        {
           
            if (string.IsNullOrEmpty(Brand)) throw new BusinessLogicException("Brand cannot be empty.");
            return $"{Brand}-{Model}-{ManufactureYear}-{TextGenerationUtility.GenerateRandomDigits(4).ToUpperInvariant()}";
        }
        public Vehicle() { }

        public Vehicle(long customerId, string brand, string model, int manufactureYear, string? plateNumber,
               decimal odometerBefore,
               decimal odometerAfter, VehicleCondition condition)
        {
            CustomerId = customerId;
            Brand = brand;
            PlateNumber = plateNumber;
            OdometerBefore = odometerBefore;
            OdometerAfter = odometerAfter;
            InitialCondition = condition;
            GeneratedId = GenerateId();
            Model = model;
            ManufactureYear = manufactureYear;


            if (customerId <= 0)
            {
                throw new BusinessLogicException("Vehicle must be assigned to customer");
            }

            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new BusinessLogicException("Brand name cannot be empty or whitespace");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new BusinessLogicException("Model name cannot be empty, or whitespace.");
            }

            int currentYear = DateTime.Now.Year;
            if (manufactureYear < 1886 || manufactureYear > currentYear + 1)
            {
                throw new BusinessLogicException($"ManufactureYear must be between 1886 and {currentYear + 1}.");
            }

            if (odometerBefore < 0)
            {
                throw new BusinessLogicException("OdometerBefore cannot be negative.");
            }

            if (odometerAfter < 0)
            {
                throw new BusinessLogicException("OdometerAfter must be greater than zero.");
            }

            if (odometerAfter != 0 && odometerAfter < odometerBefore)
            {
                throw new BusinessLogicException("Odometer reading after cannot be less than OdometerBefore.");
            }

            
        }
    }
}
