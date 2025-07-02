using System.Collections;
using Mechanic.Domain.Common;
using Mechanic.Domain.Entities;
using Mechanic.Domain.Enums;

namespace Mechanic.EntityTests.VehicleTests
{
    [TestFixture]
    public class VehicleConstructorCreationTests
    {
        [TestCaseSource(typeof(VehicleCreationTestCasesData), nameof(VehicleCreationTestCasesData.GoodVehicleData))]
        public void GoodDataTests(long customerId, string brand, string model, int manufactureYear, string? plateNumber, decimal odometerBefore, decimal odometerAfter, VehicleCondition initCondition)
        {
            Vehicle vehicle = null;
            try
            {
                vehicle = new Vehicle(customerId, brand, model, manufactureYear, plateNumber, odometerBefore, odometerAfter, initCondition);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Good data case unexpectedly threw an exception: {ex.Message}");
            }
            Assert.That(vehicle, Is.Not.Null, "Vehicle should not be null after creation.");
            Assert.That(vehicle.CustomerId, Is.EqualTo(customerId), "Customer ID mismatch.");
            Assert.That(vehicle.Brand, Is.EqualTo(brand), "Brand mismatch.");
            Assert.That(vehicle.Model, Is.EqualTo(model), "Model mismatch.");
            Assert.That(vehicle.ManufactureYear, Is.EqualTo(manufactureYear), "Manufacture year mismatch.");
            Assert.That(vehicle.PlateNumber, Is.EqualTo(plateNumber), "Plate number mismatch.");
            Assert.That(vehicle.OdometerBefore, Is.EqualTo(odometerBefore), "Odometer before mismatch.");
            Assert.That(vehicle.OdometerAfter, Is.EqualTo(odometerAfter), "Odometer after mismatch.");
            Assert.That(vehicle.GeneratedId, Is.Not.Null.And.Not.Empty, "Generated ID should not be null or empty.");
            Assert.That(vehicle.DateCreated, Is.LessThanOrEqualTo(DateTime.UtcNow));
            Assert.That(vehicle.DateModified, Is.LessThanOrEqualTo(DateTime.UtcNow));
            Assert.That(vehicle.DateCreated, Is.EqualTo(vehicle.DateModified).Within(TimeSpan.FromSeconds(1)));
            Assert.That(vehicle.InitialCondition, Is.EqualTo(vehicle.InitialCondition), "Vehicle condition mismatch");
        }

        [TestCaseSource(typeof(VehicleCreationTestCasesData), nameof(VehicleCreationTestCasesData.BadVehicleData))]
        public void BadDataTests(long customerId, string brand, string model, int manufactureYear, string? plateNumber, decimal odometerBefore, decimal odometerAfter, VehicleCondition condition)
        {
            var ex = Assert.Throws<BusinessLogicException>(() =>
            {
                new Vehicle(customerId, brand, model, manufactureYear, plateNumber, odometerBefore, odometerAfter, condition);
            });

            Assert.That(ex.Message, Is.Not.Null, "Exception message should not be empty.");
        }
    }

    public class VehicleCreationTestCasesData
    {
        public static IEnumerable GoodVehicleData
        {
            get
            {
                yield return new TestCaseData(
                    1, "Toyota", "Camry", 2020, "ABC123",
                    50000m, 50000m, VehicleCondition.Good
                                             );
                yield return new TestCaseData(
                    2, "Honda", "Civic", 2018, null,
                    75000.5m, 75000.5m, VehicleCondition.Fair
                                             );
                yield return new TestCaseData(
                    3, "Ford", "F-150", 2022, "XYZ789",
                    10000m, 10000m, VehicleCondition.Excellent
                                             );
                yield return new TestCaseData(
                    4, "Tesla", "Model 3", 2023, "EV456",
                    15000m, 15000m, VehicleCondition.Good
                                             );
                yield return new TestCaseData(
                    5, "BMW", "X5", 2021, "PQR007",
                    30000m, 30000m, VehicleCondition.Good);
            }
        }

        public static IEnumerable BadVehicleData
        {
            get
            {
                yield return new TestCaseData(
                    0, "Toyota", "Camry", 2020, "ABC123",
                    50000m, 50000m, VehicleCondition.Poor
                                             );
                yield return new TestCaseData(
                    -1, "Toyota", "Camry", 2020, "ABC123",
                    50000m, 50000m, VehicleCondition.Good
                                             );

                yield return new TestCaseData(
                    1, "", "Camry", 2020, "ABC123",
                    50000m, 50000m, VehicleCondition.Good
                                             );
                yield return new TestCaseData(
                    1, " ", "Camry", 2020, "ABC123",
                    50000m, 50000m, VehicleCondition.Good
                                             );
                yield return new TestCaseData(
                    1, null, "Camry", 2020, "ABC123",
                    50000m, 50000m, VehicleCondition.Good
                                             );

                yield return new TestCaseData(
                    1, "Toyota", "", 2020, "ABC123",
                    50000m, 50000m, VehicleCondition.Good
                                             );

                yield return new TestCaseData(
                    1, "Toyota", "Camry", 1800, "ABC123",
                    50000m, 50000m, VehicleCondition.Good
                                             );
                yield return new TestCaseData(
                    1, "Toyota", "Camry", DateTime.Now.Year + 2, "ABC123",
                    50000m, 50000m, VehicleCondition.Good
                                             );

                yield return new TestCaseData(
                    1, "Toyota", "Camry", 2020, "ABC123",
                    -100m, 50000m, VehicleCondition.Good
                                             );
                yield return new TestCaseData(
                    1, "Toyota", "Camry", 2020, "ABC123",
                    50000m, -100m, VehicleCondition.Good
                                             );
                yield return new TestCaseData(
                    1, "Toyota", "Camry", 2020, "ABC123",
                    50000m, 40000m, VehicleCondition.Good
                                             );
            }
        }
    }
}