using static CarApp.Vehicles.Car;

namespace CarApp.Vehicles
{
    public class DinBil
    {
        
        public static Car userCar = null;

        public void DinBilInfo()
        {
            Console.Write("Enter car brand: ");
            string yourCarBrand = Console.ReadLine();

            Console.Write("Enter car model: ");
            string yourCarModel = Console.ReadLine();

            int yourCarYear;
            Console.Write("Enter car year: ");
            while (!int.TryParse(Console.ReadLine(), out yourCarYear) || yourCarYear <= 1886)
            {
                Console.Write("Invalid input. Please enter a valid year: ");
            }

            Console.Write("Which geartype is the car using? (A/M): ");
            char yourGearType;
            while (!char.TryParse(Console.ReadLine().ToUpper(), out yourGearType) || (yourGearType != 'A' && yourGearType != 'M'))
            {
                Console.Write("Invalid input. Please enter a single character for gear type: ");
            }

            int yourCarMilage;
            Console.Write("What's the current mileage: ");
            while (!int.TryParse(Console.ReadLine(), out yourCarMilage))
            {
                Console.Write("Invalid input. Please enter a valid number: ");
            }

            FuelType fuelType;
            while (true)
            {
                Console.Write("Enter fuel type (benzin, diesel, electric, hybrid): ");
                string fuelInput = Console.ReadLine()?.Trim().ToLower();

                switch (fuelInput)
                {
                    case "benzin":
                    case "b":
                        fuelType = FuelType.Benzin;
                        break;
                    case "diesel":
                    case "d":
                        fuelType = FuelType.Diesel;
                        break;
                    case "electric":
                    case "e":
                        fuelType = FuelType.Electric;
                        break;
                    case "hybrid":
                    case "h":
                        fuelType = FuelType.Hybrid;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter 'benzin', 'diesel', 'electric', or 'hybrid'.");
                        continue;
                }
                break;
            }

            double fuelEfficiency;
            Console.Write("Enter fuel efficiency (km per liter/kWh per km): ");
            while (!double.TryParse(Console.ReadLine(), out fuelEfficiency) || fuelEfficiency <= 0)
            {
                Console.Write("Invalid input. Please enter a valid fuel efficiency: ");
            }

            // Opretter bilen med alle oplysninger
            userCar = new Car(yourCarBrand, yourCarModel, yourCarYear, yourGearType, yourCarMilage, fuelType, fuelEfficiency);

            // Udskriv bilens information
            Console.WriteLine("\nCar details have been saved.");
            userCar.MinBil();
        }
    }
}
