using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annettes_carapp
{
    internal class Car
    {
        private string brand;
        private string model;
        private int year;
        private char gearType;
        private double odometer;
        private string fuelType;
        private double literPricePetrol= 13.49;
        private double literPriceDiesel= 12.29;
        private bool isEngineOn;
        private double kmPerLiter;
        private double distance;

        //Egenskaber for adgang til attributter
        public string Brand
        {
            get { return brand; }
            private set { brand = value; }
        }
        public string Model
        {
            get { return model; }
            private set { model = value; }
        }
        public int Year
        {
            get { return year; }
            private set {  year = value; }
        }
        public char GearType
        {
            get { return gearType;}
            private set { gearType = value; }
        }
        public double Odometer
        {
            get { return odometer; }
            private set // Kun metoder i klassen kan ændre odometeret
            {
                if (value >= odometer) // Odometer kan ikke gå baglæns
                    odometer = value;
                else
                    Console.WriteLine("Fejl: Odometer kan ikke sættes lavere end den nuværende værdi.");
            }
        }
        public string FuelType
        {
            get { return fuelType; }
            private set
            {
                if (value.ToLower() == "benzin" || value.ToLower() == "diesel")
                    fuelType = value.ToLower();
                else
                    Console.WriteLine("Fejl: Brændstoftype skal være 'benzin' eller 'diesel'.");
            }
        }
        public double KmPerLiter
        {
            get { return kmPerLiter; }
            private set { kmPerLiter = value; }
        }

        //Constructor til at initialisere bilen
        public Car(string brand, string model, int year, char geartype, string fuelType, double kmPerLiter, double odometer = 0)
        {
            Brand = brand;
            Model = model;
            Year = year;
            GearType = geartype;
            Odometer = odometer;
            FuelType = fuelType;
            KmPerLiter = kmPerLiter;
            isEngineOn = false; // Standard: motoren er slukket ved start
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

            Console.Write("Indtast brændstoftype (benzin eller diesel): ");
            fuelType = Console.ReadLine().ToLower();

            Console.Write("Indtast km per liter: ");
            kmPerLiter = Convert.ToDouble(Console.ReadLine());

            Console.Write("Indtast antal kørte km: ");
            odometer = Convert.ToDouble(Console.ReadLine());
        }

        //Simulerer en køretur
        public void Drive()
        {
            Console.WriteLine("\nHar du tændt bilen (ja elller nej)?");
            string motor = Console.ReadLine().ToLower();

            if (motor == "ja")
            {
                isEngineOn = true;
                Console.WriteLine("\nHvor langt har du kørt?");
                distance = Convert.ToDouble(Console.ReadLine());

                odometer += distance; //Opdaterer odometeret
                Console.WriteLine($"\nBilens odometer er nu på: {odometer}km");
            }
            else
            {
                Console.WriteLine("\nTænd bilen for at kunne køre");
            }
        }

        //Beregner prisen for en tur baseret på brændstoftype
        public void CalculateTripPrice()
        {
            if (fuelType != "benzin" && fuelType != "diesel")
            {
                Console.WriteLine("\nUgyldig brændstoftype.");
                return;
            }

            double fuelNeeded = distance / kmPerLiter; //beregner nødvendigt brændstof

            //Beregning af turpris baseret på brændstoftype
            double tripCost;
            if (fuelType == "diesel")
            {
                tripCost = fuelNeeded * literPriceDiesel;
            }
            else
            {
                tripCost = fuelNeeded * literPricePetrol;
            }
            Console.WriteLine($"\nBrændstofomkostninger for turen på {distance}km: {tripCost}kr");
        }
        
        //Udskriver bilens detaljer
        public void PrintCarDetails()
        {
            Console.WriteLine($"\nDette er din bil: \nBilmærke: {brand} \nModel: {model} \nÅrgang: {year} \nGear: {gearType} \nBrændstoftype: {fuelType} \nKm/l: {kmPerLiter} \nOdometer: {odometer} km");
        }
    }
}
