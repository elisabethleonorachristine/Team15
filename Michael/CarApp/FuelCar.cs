using CarApp.Vehicles;

namespace CarApp.Specialized
{
    public class FuelCar : Car , IEnergy
    {
        public double FuelLevel { get; private set; }
        public double FuelTankCapacity { get; private set; }
        public double KmPerLiter { get; private set; }
        public double EnergyLevel => FuelLevel;
        public double MaxEnergy => FuelTankCapacity;

        public FuelCar(string brand, string model, int year, char gear, int milage, FuelType fuel,
                   double fuelLevel, double tankCapacity, double kmPerLiter)
        : base(brand, model, year, gear, milage, fuel)
        {
            FuelLevel = fuelLevel;
            FuelTankCapacity = tankCapacity;
            KmPerLiter = kmPerLiter;
        }

        public void Refill(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Cannot refuel with zero or negative amount.");
                return;
            }

            if (FuelLevel + amount > FuelTankCapacity)
            {
                Console.WriteLine("Refuel amount exceeds tank capacity.");
                return;
            }

            FuelLevel += amount;
            Console.WriteLine($"Refueled {amount} liters. New level: {FuelLevel} liters.");
        }

        public void UseEnergy(double kilometers)
        {
            double neededFuel = kilometers / KmPerLiter;

            if (FuelLevel < neededFuel)
            {
                Console.WriteLine("Not enough fuel to drive that far.");
                return;
            }

            FuelLevel -= neededFuel;
            Console.WriteLine($"Used {neededFuel:F2} liters for {kilometers} km. Remaining: {FuelLevel:F2} liters.");
        }

        public override void Drive(Trip trip)
        {
            double neededFuel = trip.tripDistance / KmPerLiter;

            if (FuelLevel < neededFuel)
            {
                Console.WriteLine("Not enough fuel for the trip.");
                return;
            }

            trips.Add(trip);
            AddMilage((int)trip.tripDistance);
            FuelLevel -= neededFuel;

            Console.WriteLine($"Du har kørt {trip.tripDistance} km.");
            Console.WriteLine($"Fuel remaining: {FuelLevel:F2} liters.");

            trip.PrintTripDetails(GetEfficiency(), GetFuelPrice(), carBrand);
        }

        public override double GetEfficiency() => KmPerLiter;
        public override double GetRange() => FuelLevel * KmPerLiter;
    }
}
