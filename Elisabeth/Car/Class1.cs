<<<<<<< HEAD
﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Car
{
    internal class Car
    {
        private string Brand {  get; set; }
        private string Model { get; set; }
        private int Year { get; set; }
        private char Geartype { get; set; }
        public double Odometer { get; private set; }
        public double KmPerLiter { get; private set; }
        private bool IsEngineOn {  get; set; }

        public double FuelPrice {  get; private set; } 
       

        public Car(string brand, string model, int year, char gearType, double odometer, double kmPerLiter, double fuelPrice, bool isEngineOn)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Geartype = gearType;
            Odometer = odometer;
            KmPerLiter = kmPerLiter;
            FuelPrice = fuelPrice;
           
        }
    
        public static void ReadCarDetails(out Car userCar)
        {
            
            
            Console.WriteLine("Indtast brand:");
            string brand = Console.ReadLine();
            Console.WriteLine("Indtast model:");
            string model = Console.ReadLine();
            Console.WriteLine("Indtast årgang:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast geartype:");
            char gearType = char.Parse(Console.ReadLine());
            Console.WriteLine("Indtast odometer:");
            double odometer = double.Parse(Console.ReadLine());
            Console.WriteLine("Indtast kilometer på literen:");
            double kmPerLiter = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter fuel price per liter:");
            double fuelPrice = double.Parse(Console.ReadLine());

            userCar = new Car(brand, model, year, gearType, odometer, kmPerLiter, fuelPrice, false);

            Console.WriteLine("Bilens oplysninger er gemt.");
        }
    
        public void PrintCarDetails()
        {
            Console.WriteLine($"Brand: {Brand}\nModel: {Model}\nYear: {Year}\nGeartype: {Geartype}\nOdometer: {Odometer}\nKilometres per liter: {KmPerLiter}");
    
        }
    
        public void Drive()
        {
            Console.WriteLine("Is the engine on?Y/N");
            string engineInput = Console.ReadLine() ?? "";
            if (engineInput == "Y")
            {
                IsEngineOn = true;
                Console.WriteLine("Du kører en tur");
            }
            else
            {
                IsEngineOn = false;
                Console.WriteLine("The engine is not on.");
            }
        }

        public void CalculateTripPrice()
        {
            Console.WriteLine("Indtast længden på køreturen i kilometer:");
            double distance = double.Parse(Console.ReadLine() ?? "");
            double fuelNeeded = distance / this.KmPerLiter;
            double tripPrice = fuelNeeded * this.FuelPrice;
            Console.WriteLine($"Køreturen kostede {tripPrice}", tripPrice);
        }

    }


    
}
=======
﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Car
{
    internal class Car
    {
        private string Brand {  get; set; }
        private string Model { get; set; }
        private int Year { get; set; }
        private char Geartype { get; set; }
        public double Odometer { get; private set; }
        public double KmPerLiter { get; private set; }
        private bool IsEngineOn {  get; set; }

        public double FuelPrice {  get; private set; } 
       

        public Car(string brand, string model, int year, char gearType, double odometer, double kmPerLiter, double fuelPrice, bool isEngineOn)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Geartype = gearType;
            Odometer = odometer;
            KmPerLiter = kmPerLiter;
            FuelPrice = fuelPrice;
           
        }
    
        public static void ReadCarDetails(out Car userCar)
        {
            
            
            Console.WriteLine("Indtast brand:");
            string brand = Console.ReadLine();
            Console.WriteLine("Indtast model:");
            string model = Console.ReadLine();
            Console.WriteLine("Indtast årgang:");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Indtast geartype:");
            char gearType = char.Parse(Console.ReadLine());
            Console.WriteLine("Indtast odometer:");
            double odometer = double.Parse(Console.ReadLine());
            Console.WriteLine("Indtast kilometer på literen:");
            double kmPerLiter = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter fuel price per liter:");
            double fuelPrice = double.Parse(Console.ReadLine());

            userCar = new Car(brand, model, year, gearType, odometer, kmPerLiter, fuelPrice, false);

            Console.WriteLine("Bilens oplysninger er gemt.");
        }
    
        public void PrintCarDetails()
        {
            Console.WriteLine($"Brand: {Brand}\nModel: {Model}\nYear: {Year}\nGeartype: {Geartype}\nOdometer: {Odometer}\nKilometres per liter: {KmPerLiter}");
    
        }
    
        public void Drive()
        {
            Console.WriteLine("Is the engine on?Y/N");
            string engineInput = Console.ReadLine() ?? "";
            if (engineInput == "Y")
            {
                IsEngineOn = true;
                Console.WriteLine("Du kører en tur");
            }
            else
            {
                IsEngineOn = false;
                Console.WriteLine("The engine is not on.");
            }
        }

        public void CalculateTripPrice()
        {
            Console.WriteLine("Indtast længden på køreturen i kilometer:");
            double distance = double.Parse(Console.ReadLine() ?? "");
            double fuelNeeded = distance / this.KmPerLiter;
            double tripPrice = fuelNeeded * this.FuelPrice;
            Console.WriteLine($"Køreturen kostede {tripPrice}", tripPrice);
        }

    }


    
}
>>>>>>> c6ac4874b3687bd9a6de559dbe7f6f0ecbbea542
