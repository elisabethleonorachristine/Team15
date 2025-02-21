using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Michael
{
    public class DinBil
    {
        // Gemmer den bil, der er oprettet i denne klasse
        public static Bil userCar = null;
        public void DinBilInfo()
        {
            Console.Write("Enter car brand: ");
            string yourCarBrand = Console.ReadLine();

            Console.Write("Enter car model: ");
            string yourCarModel = Console.ReadLine();

            int yourCarYear;
            Console.Write("Enter car year: ");
            while (!int.TryParse(Console.ReadLine(), out yourCarYear))
            {
                Console.Write("Invalid input. Please enter a valid year: ");
            }

            Console.Write("Which geartype is the car using? (A/M): ");
            char yourGearType;
            while (!char.TryParse(Console.ReadLine(), out yourGearType))
            {
                Console.Write("Invalid input. Please enter a single character for gear type: ");
            }

            int yourCarMilage;
            Console.Write("Whats the current milage: ");
            while (!int.TryParse(Console.ReadLine(), out yourCarMilage))
            {
                Console.Write("Invalid input. Please enter a valid year: ");
            }

            userCar = new Bil(yourCarBrand, yourCarModel, yourCarYear, yourGearType, yourCarMilage);

            // Udskriv bilens information
            Console.WriteLine("\nCar details have been saved.");
            userCar.MinBil();
        }
    }
}
