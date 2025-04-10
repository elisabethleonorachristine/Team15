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
            return Math.Round(tripDistance / fuelEfficiency,2);
        }

        // Beregn turens pris baseret på brændstofpris
        public double CalculateTripPrice( double fuelEfficiency, double literPrice)
        {
            try
            {
                return Math.Round(CalculateFuelUsed(fuelEfficiency) * literPrice,2);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Fejl: Brændstofforbrug kan ikke være 0. Turens pris kunne ikke beregnes.");
                return 0;
            }
        }

        // Udskriv turens detaljer
        public void PrintTripDetails(double kmPrLiter, double literPrice, string carBrand)
        {
            Console.WriteLine($" Tur detaljer:");
            Console.WriteLine($"- Mærke: {carBrand}");
            Console.WriteLine($"- Distance: {tripDistance} km");
            Console.WriteLine($"- Dato Oprettet: {tripDate.ToShortDateString()}");
            Console.WriteLine($"- Starttid: {tripStartTime}");
            Console.WriteLine($"- Sluttid: {tripEndTime}");
            Console.WriteLine($"- Varighed: {CalculateDuration()}");
            Console.WriteLine($"- Brændstof brugt: {CalculateFuelUsed(kmPrLiter)} L");
            Console.WriteLine($"- Turens pris: {CalculateTripPrice(kmPrLiter, literPrice)} kr\n");
        }

        //Gemme metoder
        public override string ToString()
        {
            return $"Trip: {tripDistance}, {tripDate:dd-MM-yyyy}, {tripStartTime:HH:mm}, {tripEndTime:HH:mm}";
        }

        public static Trip FromString(string tripData)
        {
            // Eksempel: Trip: 120.5, 12-03-2024, 08:30, 10:15
            var parts = tripData.Replace("Trip: ", "").Split(", ");
            double distance = double.Parse(parts[0]);
            DateTime date = DateTime.ParseExact(parts[1], "dd-MM-yyyy", null);
            DateTime startTime = DateTime.ParseExact($"{parts[1]} {parts[2]}", "dd-MM-yyyy HH:mm", null);
            DateTime endTime = DateTime.ParseExact($"{parts[1]} {parts[3]}", "dd-MM-yyyy HH:mm", null);
            return new Trip(distance, startTime, endTime);
        }

    }
}
