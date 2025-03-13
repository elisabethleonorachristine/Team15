using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annettes_carapp
{
    //Fueltype enum
    public enum FuelType
    {
        Benzin,
        Diesel,
        Electric,
        Hybrid
    }

    internal class Car
    {
        private string brand;
        private string model;
        private int year;
        private char gearType;
        private double odometer;
        private bool isEngineOn;
        private double kmPerLiter;
        private FuelType fuelType;
        private List<Trip> trips;

        //Egenskaber for adgang til attributter
        public string Brand {get { return brand; } private set { brand = value; }}
        public string Model {get { return model; } private set { model = value; }}
        public int Year {get { return year; } private set {  year = value; }}
        public char GearType {get { return gearType;} private set { gearType = value; }}
        public double Odometer
        {
            get { return odometer; }
            private set
            {
                if (value >= odometer) // Odometer kan ikke gå baglæns
                    odometer = value;
                else
                    Console.WriteLine("Fejl: Odometer kan ikke sættes lavere end den nuværende værdi.");
            }
        }
        public FuelType Fuel {get { return fuelType; } private set { fuelType = value; }}

        public double KmPerLiter {get { return kmPerLiter; } private set { kmPerLiter = value; }}

        //Constructor til at initialisere bilen
        public Car(string brand, string model, int year, char geartype, FuelType fuel, double kmPerLiter, double odometer = 0)
        {
            Brand = brand;
            Model = model;
            Year = year;
            GearType = geartype;
            Odometer = odometer;
            Fuel = fuel;
            KmPerLiter = kmPerLiter;
            isEngineOn = false; // Standard: motoren er slukket ved start
            trips = new List<Trip>(); //Initialiserer trips-listen
        }

        //Læser bilens detaljer
        public void ReadCarDetails()
        {
            Console.Write("\n\nIndtast bilmærke: ");
            brand = Console.ReadLine();

            Console.Write("Indtast model: ");
            model = Console.ReadLine();

            Console.Write("Indtast årgang: ");
            year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Indtast gear type (M for manuel, A for automatisk): ");
            gearType = Convert.ToChar(Console.ReadLine().ToUpper());

            //Menu hvor man kan vælge fueltype
            Console.WriteLine("Vælg brændstoftype:");
            foreach (FuelType ft in Enum.GetValues(typeof(FuelType)))
            {
                // Vi antager, at enum'ens underliggende værdier starter ved 0
                Console.WriteLine($"{(int)ft} - {ft}");
            }

            // Læs brugerens input og konverterer det til FuelType
            Console.Write("Indtast nummeret for brændstoftype: ");
            string input = Console.ReadLine();
            int choice;
            while (!int.TryParse(input, out choice) ||
                   !Enum.IsDefined(typeof(FuelType), choice))
            {
                Console.Write("Ugyldigt valg. Indtast venligst et gyldigt nummer: ");
                input = Console.ReadLine();
            }
            // Konverter tallet til enum-værdien
            fuelType = (FuelType)choice;

            Console.Write("Indtast km per liter: ");
            kmPerLiter = Convert.ToDouble(Console.ReadLine());

            Console.Write("Indtast antal kørte km: ");
            odometer = Convert.ToDouble(Console.ReadLine());
        }

        //Simulerer en køretur og gemmer den i trips-listen
        public void Drive()
        {
            Console.WriteLine("\nHar du tændt bilen (ja elller nej)?");
            string motor = Console.ReadLine().ToLower();

            if (motor == "ja")
            {
                isEngineOn = true;
                Console.WriteLine("\nIndtast distance i km: ");
                double distance = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Indtast starttidspunkt (hh:mm): ");
                DateTime startTime = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Indtast sluttidspunkt (hh:mm): ");
                DateTime endTime = DateTime.Parse(Console.ReadLine());

                //Opretter en ny tur
                Trip newTrip = new Trip(distance, DateTime.Now, startTime, endTime);
                trips.Add(newTrip);
                odometer += distance; //Opdaterer odometeret
                Console.WriteLine($"\nTuren er gemt. Bilens odometer er nu på: {odometer}km");
            }
            else
            {
                Console.WriteLine("\nTænd bilen for at kunne køre");
            }
        }


        //Literpris baseret på brændstoftype
        public double GetFuelPrice()
        {
            switch (Fuel)
            {
                case FuelType.Benzin: return 13.49;
                case FuelType.Diesel: return 12.29;
                case FuelType.Electric: return 10;
                case FuelType.Hybrid: return 11;
                default:
                    throw new Exception("Ugyldig Brændstoftype");
            }
        }
        
        //Printer turens detaljer
        public void PrintAllTrips()
        {
            if (trips.Count == 0)
            {
                Console.WriteLine("\nIngen registrerede ture.");
                return;
            }

            Console.WriteLine("\n--- Alle registrerede ture ---");
            foreach (var trip in trips)
            {
                trip.PrintTripDetails(this); // Sender bilen med som parameter
            }
        }

        //Udskriver bilens detaljer
        public void PrintCarDetails()
        {
            Console.WriteLine($"\nDette er din bil: \nBilmærke: {Brand} \nModel: {Model} \nÅrgang: {Year} \nGear: {GearType} \nBrændstoftype: {Fuel} \nKm/l: {KmPerLiter} \nOdometer: {Odometer} km");
        }
    }
}
