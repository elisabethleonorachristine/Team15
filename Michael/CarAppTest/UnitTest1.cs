using CarApp;
using CarApp.Vehicles;
using CarApp.TeamCars;

namespace CarAppTest

{
    [TestClass]
    public sealed class UnitTest1
    {
        private Car car;
        private Car car2;

        [TestInitialize]
        public void TestInitialize()
        {
            
            car = new Car("Toyota", "Corolla", 2022, 'A', 1000, Car.FuelType.Benzin, 15.0);

            car.Drive(new Trip(50, new DateTime(2024, 3, 10, 10, 0, 0), new DateTime(2024, 3, 10, 10, 30, 0))); // 10. marts 2024
            car.Drive(new Trip(70, new DateTime(2024, 3, 10, 14, 0, 0), new DateTime(2024, 3, 10, 14, 45, 0))); // 10. marts 2024
            car.Drive(new Trip(30, new DateTime(2024, 3, 11, 9, 0, 0), new DateTime(2024, 3, 11, 9, 20, 0)));  // 11. marts 2024
            
            car2 = new Car("Audi", "TT", 2025, 'A', 1000, Car.FuelType.Benzin, 15.0);

        }


        [TestMethod]
        public void TestDrive_UpdatesOdometer_WhenCarIsOn()
        {
            // Arrange
            car.TurnCarOn();
            double initialMileage = car.totalMilage;
            double distance = 50;
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddMinutes(30);
            Trip trip = new Trip(distance, startTime, endTime);

            // Act
            car.Drive(trip);

            // Assert
            Assert.AreEqual(initialMileage + distance, car.totalMilage); // Odometer skal være opdateret
        }

        [TestMethod]
        public void TestDrive_DoesNotUpdateOdometer_WhenCarIsOff()
        {
            // Arrange

            double initialMileage = car.totalMilage; // Gem odometer
            double distance = 50;
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddMinutes(30);
            Trip trip = new Trip(distance, startTime, endTime);


            // Act
            car.TurnCarOff();
            car.Drive(trip); // Prøv at køre med motoren slukket

            // Assert
            string expectedOutput = "The car is now turned off.";

        }

       
        [TestMethod]
        public void TestMethodAddMilage()
        {
            //Arrange            
            int distance = 100;
            //Act
            car2.AddMilage(distance);
            //Assert
            Assert.AreEqual(1100, car2.totalMilage);
        }

        [TestMethod]
        public void TestGetTripsByDate_MultipleTrips()
        {
            // Arrange
            DateTime testDate = new DateTime(2024, 3, 10);

            // Act
            List<Trip> tripsOnDate = car.GetTripsByDate(testDate);

            // Assert
            Assert.AreEqual(2, tripsOnDate.Count, "Forventede 2 ture på 10. marts 2024, men fik en anden mængde.");
        }

        [TestMethod]
        public void TestGetTripsByDate_NoTrips()
        {
            // Arrange
            DateTime testDate = new DateTime(2024, 3, 15); // Ingen ture denne dag

            // Act
            List<Trip> tripsOnDate = car.GetTripsByDate(testDate);

            // Assert
            Assert.AreEqual(0, tripsOnDate.Count, "Forventede ingen ture på 15. marts 2024, men fik nogle ture.");
        }
    }

}
