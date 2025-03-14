using System;
using System.Collections.Generic;
using static CarApp.Vehicles.Car;

namespace CarApp.Vehicles
{
    public class Trip
    {
        // Attributter med private set for indkapsling
        public double tripDistance { get; private set; }
        public DateTime tripDate { get; private set; }
        public DateTime tripStartTime { get; private set; }
        public DateTime tripEndTime { get; private set; }

        // Constructor til at initialisere en tur
        public Trip(double distance, DateTime startTime, DateTime endTime)
        {
            tripDistance = distance;
            tripDate = DateTime.Now;
            tripStartTime = startTime;
            tripEndTime = endTime;
        }

        
        public TimeSpan CalculateDuration()
        {
            return tripEndTime - tripStartTime;
        }

        // Beregn brændstofforbrug
        public double CalculateFuelUsed(double fuelEfficiency)
        {
            if (fuelEfficiency <= 0)
                return 0;
            return tripDistance / fuelEfficiency;
        }

        // Beregn turens pris baseret på brændstofpris
        public double CalculateTripPrice( double fuelEfficiency, double literPrice)
        {
            return CalculateFuelUsed(fuelEfficiency) * literPrice;
        }

        // Udskriv turens detaljer
        public void PrintTripDetails(double kmPrLiter, double literPrice)
        {
            Console.WriteLine($" Tur detaljer:");
            Console.WriteLine($"- Distance: {tripDistance} km");
            Console.WriteLine($"- Dato: {tripDate.ToShortDateString()}");
            Console.WriteLine($"- Starttid: {tripStartTime}");
            Console.WriteLine($"- Sluttid: {tripEndTime}");
            Console.WriteLine($"- Varighed: {CalculateDuration()}");
            Console.WriteLine($"- Brændstof brugt: {CalculateFuelUsed(kmPrLiter)} L");
            Console.WriteLine($"- Turens pris: {CalculateTripPrice(kmPrLiter, literPrice)} kr\n");
        }
    }
}
