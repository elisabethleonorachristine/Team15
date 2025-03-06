using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace CarApp
{
    internal class Car
    {
        private string brand;
        private string model;
        private string brændstofstype;
        private char geartype;
        private double kmPerLiter;
        private int year;
        private int kmStand;
        private bool isEngineOn = false;

        public Car(string brand, string model, string brændstofstype, char geartype, double kmPerLiter, int year, int kmStand, bool isEngineOn)
        {
            this.brand = brand;
            this.model = model;
            this.brændstofstype = brændstofstype;
            this.geartype = geartype;
            this.kmPerLiter = kmPerLiter;
            this.year = year;
            this.kmStand = kmStand;
            this.isEngineOn = false;
        }

        public string getBrand() { return brand; }
        public void setBrand(string brand) { this.brand = brand; }
        
        public string getModel() { return model; }
        public void setModel(string model) { this.model = model; }
        
        public string getBrændstofstype() { return brændstofstype; }
        public void setBrændstofstype(string brændstofstype) { this.brændstofstype = brændstofstype; }
        
        public char getGeartype() { return geartype; }
        public void setGeartype(char geartype) {  this.geartype = geartype; }

        public double getkmPerLiter() { return kmPerLiter; }
        public void setkmPerLiter(double kmPerliter) { this.kmPerLiter=kmPerliter; }

        public int getYear() { return year; }
        public void setYear(int year) { this.year = year; }  

        public int getKMStand() { return kmStand; }
        public void setKMStand(int kmStand) {  this.kmStand = kmStand; }
       
        public bool getisEngineOn() { return isEngineOn; }
        public void setIsEnginOn(bool isEngineOn) { this.isEngineOn = isEngineOn; }


        public void StartEngine()
        {
            isEngineOn = true;
            Console.WriteLine("Motoren er tændt.");
        }
        public void Drive(double distance)
        {
            if (isEngineOn)
            {
                kmStand += (int)distance;
                Console.WriteLine("Bilen har kørt " + distance + " km og den har nu en km stand på " + kmStand);
            }
            else
            {
                Console.WriteLine("Motoren er ikke tændt, derfor kan bilen ikke køre");
            }
        }
        public double CalculateTripPrice(double distance)
        {

            //// Brændstofpriser
            double fuelPrizeB = 13.49;
            double fuelPrizeD = 12.29;
            double tripCost;


            if (kmPerLiter == 0)
            {
                Console.WriteLine("Ugyldigt input:");
                return 0;
            }


            //// Beregn prisen baseret på brændstoftypen
            double fuelNeeded = distance / kmPerLiter;
            if (brændstofstype.ToLower() == "benzin")
            {
                tripCost = fuelNeeded * fuelPrizeB;

            }
            else if (brændstofstype.ToLower() == "diesel")
            {
                tripCost = fuelNeeded * fuelPrizeD;

            }
            else
            {
                Console.WriteLine("Ugyldig brændstoftype.Prisen kan ikke beregnes");
                return 0;
            }
            return tripCost;
        }
        public void PrintCarDetails()
        {
            Console.WriteLine("Bilens mærke: " + brand);
            Console.WriteLine("Bilens model: " + model);
            Console.WriteLine("Bilens årgang: " + year);
            Console.WriteLine("Bilens geartype: " + geartype);
            Console.WriteLine("Bilens brændstoftype: " + brændstofstype);
            Console.WriteLine("Denne bil kan køre " + kmPerLiter + " km pr. liter");
            Console.WriteLine("Bilens nuværende km stand: " + kmStand);
            Console.WriteLine("Hvor langt vil du have bilen skal køre?");
            double distance = Convert.ToDouble(Console.ReadLine());
            double tripPrice = CalculateTripPrice(distance);
            if (distance > 0)
            {
                Console.WriteLine("Prisen for at køre " + distance + " km er " + tripPrice + "kr.");

            }
            else
            {
                Console.WriteLine("Prisen kan ikke beregnes");
            }

            bool isPalindrome = Program.IsPalindrome(kmStand);
            if (isPalindrome)
            {
                Console.WriteLine("Bilens km. stand er et palindrome");
            }
            else
            {
                Console.WriteLine("Bilens km stand er ikke et palindrome");
            }
        }
    }
}
