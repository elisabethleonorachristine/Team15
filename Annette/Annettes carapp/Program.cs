using System.Collections.Generic;
using System.Globalization;

namespace Annettes_carapp
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Opret instanser af car (bilobjekter)
            Car car1 = new Car("Skoda", "Octavia", 2020, 'M', FuelType.Benzin, 20, 50000);
            Car car2 = new Car("Audi", "A1", 2018, 'A', FuelType.Diesel, 18, 20000);
            Car car3 = new Car("Toyota", "Corolla", 2024, 'M', FuelType.Electric, 16, 10000);

            //Liste til at gemme bilerne
            List<Car> cars = new List<Car> {car1, car2, car3};

            //Menu
            int choice;
            do
            {
                Console.WriteLine("\n\nMENU:");
                Console.WriteLine("1: Read Car Details");
                Console.WriteLine("2: Drive");
                Console.WriteLine("3: Calculate Trip Price");
                Console.WriteLine("4: IsPalindrome (Ikke implementeret)");
                Console.WriteLine("5: Print Car Details");
                Console.WriteLine("6: Print All Team Cars");
                Console.WriteLine("7: Afslut programmet");
                Console.Write("\nVælg en mulighed: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("\nVælg en bil (1, 2 eller 3): ");
                        int carIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (carIndex >= 0 && carIndex < cars.Count)
                            cars[carIndex].ReadCarDetails();
                        else
                            Console.WriteLine("Ugyldigt valg.");
                        break;
                    case 2:
                        Console.Write("\nVælg en bil (1, 2 eller 3): ");
                        carIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (carIndex >= 0 && carIndex < cars.Count)
                            cars[carIndex].Drive();
                        else
                            Console.WriteLine("Ugyldigt valg.");
                        break;
                    case 3:
                        Console.Write("\nVælg en bil (1, 2 eller 3): ");
                        carIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (carIndex >= 0 && carIndex < cars.Count)
                            cars[carIndex].PrintAllTrips();
                        else
                            Console.WriteLine("Ugyldigt valg.");
                        break;
                    /*case 4:
                        IsPalindrome();
                        break;*/
                    case 5:
                        Console.Write("\nVælg en bil (1, 2 eller 3): ");
                        carIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (carIndex >= 0 && carIndex < cars.Count)
                            cars[carIndex].PrintCarDetails();
                        else
                            Console.WriteLine("Ugyldigt valg.");
                        break;
                    case 6:
                        PrintAllCars(cars);
                        break;
                    case 7:
                        Console.WriteLine("\nProgrammet afsluttes...");
                        break;
                    default:
                        Console.WriteLine("\nUgyldigt valg, prøv igen.");
                        break;
                }
            }
            while (choice != 7);
        }

        //Udskriver alle biler
        static void PrintAllCars(List<Car> cars)
        {
            Console.WriteLine("\nBILLISTE:");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("| {0,-12} | {1,-10} | {2,-6} | {3,-10} | {4,-10} | {5,-10} | {6,-7} |",
                "Mærke", "Model", "År", "Km/L", "Odometer", "Brændstof", "Gear");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            foreach (var car in cars)
            {
                Console.WriteLine("| {0,-12} | {1,-10} | {2,-6} | {3,-10:F1} | {4,-10:F0} | {5,-10} | {6,-7} |",
                    car.Brand, car.Model, car.Year, car.KmPerLiter, car.Odometer, car.Fuel, car.GearType);
            }

            Console.WriteLine("---------------------------------------------------------------------------------------");
        }

        










        /*public bool IsPalindrome(int odometer)
        {
            Console.WriteLine($"\nDit odometer er på: {odometer}");
            string kmStr=odometer.ToString();
            char[] odometerArray=kmStr.ToCharArray();
            Array.Reverse(odometerArray);
            string reversedStr=new string(odometerArray);
            return kmStr == reversedStr;
        }*/
    }
}
