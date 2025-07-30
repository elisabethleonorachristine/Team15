using CarApp.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Specialized
{
    public class ElectricCar : Car, IEnergy
    {
        public double BatteryLevel { get; private set; }
        public double BatteryCapacity { get; private set; }
        public double KmPerKwh { get; private set; }
        public double ChargeTime { get; private set; }
        public double EnergyLevel => BatteryLevel;
        public double MaxEnergy => BatteryCapacity;

        public ElectricCar(string brand, string model, int year, char gear, int milage, FuelType fuel,
                     double batteryLevel, double batteryCapacity, double kmPerCharge, double chargeTime)
              : base(brand, model, year, gear, milage, fuel)
        {
            BatteryLevel = batteryLevel;
            BatteryCapacity = batteryCapacity;
            KmPerKwh = kmPerCharge;
            ChargeTime = chargeTime;
        }
        public void Refill(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Cannot charge with zero or negative amount.");
                return;
            }

            if (BatteryLevel + amount > BatteryCapacity)
            {
                Console.WriteLine("Charge amount exceeds battery capacity.");
                return;
            }

            double timeToCharge = (amount / BatteryCapacity) * ChargeTime;

            Console.WriteLine($"Charging... Estimated time: {timeToCharge:F1} hours simulated.");
            Thread.Sleep(500);

            BatteryLevel += amount;
            Console.WriteLine($"Charged {amount} kWh. New level: {BatteryLevel} kWh.");
        }

        public void UseEnergy(double kilometers)
        {
            double neededEnergy = kilometers / KmPerKwh;

            if (BatteryLevel < neededEnergy)
            {
                Console.WriteLine("Not enough battery for the requested distance.");
                return;
            }

            BatteryLevel -= neededEnergy;
            Console.WriteLine($"Used {neededEnergy:F2} kWh for {kilometers} km. Remaining: {BatteryLevel:F2} kWh.");
        }

        public override void Drive(Trip trip)
        {
            double neededFuel = trip.tripDistance / KmPerKwh;

            if (BatteryLevel < neededFuel)
            {
                Console.WriteLine("Not enough battery power for the trip.");
                return;
            }

            trips.Add(trip);
            AddMilage((int)trip.tripDistance);
            BatteryLevel -= neededFuel;

            Console.WriteLine($"Du har kørt {trip.tripDistance} km.");
            Console.WriteLine($"Fuel remaining: {BatteryLevel:F2} kWh.");
            Console.WriteLine($"Estimated charge time: {ChargeTime} hours.");

            trip.PrintTripDetails(GetEfficiency(), GetFuelPrice(), carBrand);
        }
        public override double GetEfficiency() => KmPerKwh;
        public override double GetRange() => BatteryLevel * KmPerKwh;
    }
}
