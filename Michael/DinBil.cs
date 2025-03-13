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

            string fuelType;
            do
            {
                Console.Write("Enter fuel type (benzin/b or diesel/d): ");
                fuelType = Console.ReadLine()?.Trim().ToLower();

                if (fuelType == "b") fuelType = "benzin";
                if (fuelType == "d") fuelType = "diesel";

                if (string.IsNullOrWhiteSpace(fuelType) || (fuelType != "benzin" && fuelType != "diesel"))
                {
                    Console.WriteLine("Invalid input. Please enter 'benzin' (b) or 'diesel' (d). Try again.");
                }

            } while (string.IsNullOrWhiteSpace(fuelType) || (fuelType != "benzin" && fuelType != "diesel"));

            // Opretter bilen med alle oplysninger
            userCar = new Car(yourCarBrand, yourCarModel, yourCarYear, yourGearType, yourCarMilage, fuelType);

            // Udskriv bilens information
            Console.WriteLine("\nCar details have been saved.");
            userCar.MinBil();
        }
    }
}
