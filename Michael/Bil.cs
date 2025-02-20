using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp
{
    public class Bil
    {
        // Felter til bilens data
        public string carBrand;
        public string carModel;
        public int carYear;
        public char gearType;
        public int totalMilage;
        public bool isCarOn = false;

        // Constructor til at initialisere en bil
        public Bil(string brand, string model, int year, char gear, int milage)
        {
            carBrand = brand;
            carModel = model;
            carYear = year;
            gearType = gear;
            totalMilage = milage;
        }

        // Metode til at vise bilens info
        public void MinBil()
        {
            Console.WriteLine($"Min bil: {carBrand} {carModel}, fra {carYear} med gearType: {gearType} og har kørt: {totalMilage}");
        }
        public void AddMilage(int distance)
        {
            totalMilage += distance;           
        }
        public void TurnCarOn()
        {
            isCarOn = true;            
            Console.WriteLine("The car is now turned on.");
        }

        public void TurnCarOff()
        {
            isCarOn = false;
            Console.WriteLine("The car is now turned off.");
        }
    }
}
