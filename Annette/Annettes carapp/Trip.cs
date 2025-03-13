using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annettes_carapp
{
    internal class Trip
    {
        private double distance;
        private DateTime tripDate;
        private DateTime startTime;
        private DateTime endTime;

        //Properties for at sikre indkapsling
        public double Distance { get { return distance; } private set { distance = value; } }
        public DateTime TripDate { get { return tripDate; } private set { tripDate = value; } }
        public DateTime StartTime { get { return startTime; } private set { startTime = value; } }
        public DateTime EndTime { get { return endTime; } private set { endTime = value; } }

        //Constructor
        public Trip(double distance, DateTime tripDate, DateTime startTime, DateTime endTime)
        {
            if (endTime <= startTime)
                throw new ArgumentException("\nSluttidspunkt skal være senere end starttidspunkt.");
            Distance = distance;
            TripDate = tripDate;
            StartTime = startTime;
            EndTime = endTime;
        }

        //Metode til udregning af turens varighed
        public TimeSpan CalculateDuration() //Hvis man laver public string i stedet behøver man ikke at skrive consolewriteline
        {
            return EndTime - StartTime;
        }

        //Beregner brændstofforbrug baseret på distance og bilens kmPerLiter
        public double CalculateFuelused(double kmPerLiter)
        {
            return Distance / kmPerLiter;
        }

        //Beregner turens pris
        public double CalculateTripPrice(Car car)
        {
            double fuelUsed=CalculateFuelused(car.KmPerLiter);
            double literPrice = car.GetFuelPrice(); //Fuelprice skal være en parameter i calculateTripPrice. Evt. som input fra brugeren.
            return fuelUsed*literPrice;
        }

        //Udskriver turens detaljer
        public void PrintTripDetails(Car car)
        {
            Console.WriteLine("\n ----Tur detaljer----");
            Console.WriteLine($"Distance: {Distance}km");
            Console.WriteLine($"Dato: {TripDate}");
            Console.WriteLine($"Starttidspunkt: {StartTime}");
            Console.WriteLine($"Sluttidspunkt: {EndTime}");
            Console.WriteLine($"Varighed: {CalculateDuration()}");
            Console.WriteLine($"Brændstofforbrug: {CalculateFuelused(car.KmPerLiter)}liter");
            Console.WriteLine($"Turens pris: {CalculateTripPrice(car):F2}kr");
        }
    }
}
