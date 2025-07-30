using CarApp.Specialized; 
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

            Console.Write("Which gear type is the car using? (A/M): ");
            char yourGearType;
            while (!char.TryParse(Console.ReadLine().ToUpper(), out yourGearType) || (yourGearType != 'A' && yourGearType != 'M'))
            {
                Console.Write("Invalid input. Please enter A or M: ");
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

            // Nu vælger vi biltype afhængigt af fuelType:
            if (fuelType == FuelType.Electric)
            {
                Console.Write("Enter battery capacity (kWh): ");
                double batteryCapacity = double.Parse(Console.ReadLine());

                Console.Write("Enter current battery level (kWh): ");
                double batteryLevel = double.Parse(Console.ReadLine());

                Console.Write("Enter kilometers per kWh: ");
                double kmPerKwh = double.Parse(Console.ReadLine());

                Console.Write("Enter estimated charge time (in hours): ");
                double chargeTime = double.Parse(Console.ReadLine());

                userCar = new ElectricCar(
                    yourCarBrand, yourCarModel, yourCarYear, yourGearType,
                    yourCarMilage, fuelType,
                    batteryLevel, batteryCapacity, kmPerKwh, chargeTime
                );
            }
            else
            {
                Console.Write("Enter fuel tank capacity (liters): ");
                double tankCapacity = double.Parse(Console.ReadLine());

                Console.Write("Enter current fuel level (liters): ");
                double fuelLevel = double.Parse(Console.ReadLine());

                Console.Write("Enter kilometers per liter: ");
                double kmPerLiter = double.Parse(Console.ReadLine());

                userCar = new FuelCar(
                    yourCarBrand, yourCarModel, yourCarYear, yourGearType,
                    yourCarMilage, fuelType,
                    fuelLevel, tankCapacity, kmPerLiter
                );
            }

            // Gem og vis bilen
            DataHandler dataHandler = new DataHandler("cars.txt");
            dataHandler.SaveSingleCar(userCar);

            Console.WriteLine("\nCar details have been saved.");
            userCar.MinBil();
        }
    }
}
