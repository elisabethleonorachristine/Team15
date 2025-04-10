namespace CarApp.Vehicles
{
    public class Car // Skabelon for bilen
    {
        public enum FuelType
        {
            Benzin,
            Diesel,
            Electric,
            Hybrid
        }

        public string carBrand { get; set; }
        public string carModel { get; set; }
        public int carYear { get; set; }
        public char gearType { get; set; }
        public int totalMilage { get; private set; }
        public FuelType fuelType { get; set; }
        public double fuelEfficiency { get; private set; }
        public bool isCarOn = false;

        public List<Trip> trips;

        // Constructor til at initialisere en bil
        public Car(string brand, string model, int year, char gear, int milage, FuelType fuel, double efficiency)
        {
            carBrand = brand;
            carModel = model;
            carYear = year;
            gearType = gear;
            totalMilage = milage;
            fuelType = fuel;
            fuelEfficiency = efficiency;
            trips = new List<Trip>();
        }
        
           

        public void MinBil()
        {
            Console.WriteLine($"Min bil: {carBrand} {carModel}, fra {carYear} med gearType: {gearType}, har kørt: {totalMilage} km, og kører på {fuelType} og har en brændstofeffektivitet på {fuelEfficiency} km/L.");
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

        public void IsCarTurnedOn()
        {            
            if (!isCarOn)
            {
                Console.WriteLine("The car is turned off. Do you want to turn it on? (yes/no)");
                string input = Console.ReadLine().ToLower();

                if (input == "yes" || input == "y" || input == "ye")
                {
                    DinBil.userCar.TurnCarOn();
                }
                else
                {
                    Console.WriteLine("You need to turn on the car before starting the trip.");
                    return;
                }
            }
        }

        public void Drive(Trip newTrip)
        {            
            trips.Add(newTrip);
            AddMilage((int)newTrip.tripDistance);
            Console.WriteLine($"Du har kørt {newTrip.tripDistance} km.\n");

            newTrip.PrintTripDetails(fuelEfficiency, GetFuelPrice(), carBrand);
        }
        
        
        public void PrintAllTrips(double literPrice)
        {
            if (trips.Count == 0)
            {
                Console.WriteLine("Ingen ture registreret endnu.");
                return;
            }

            Console.WriteLine("Liste over kørsler:\n");
            foreach (Trip trip in trips)
            {
                trip.PrintTripDetails(fuelEfficiency, literPrice, carBrand);
            }
        }
        public List<Trip> GetTripsByDate(DateTime date)
        {
            List<Trip> tripsOnDate = new List<Trip>();

            foreach (Trip trip in trips)
            {
                if (trip.tripStartTime.Date == date.Date) 
                {
                    tripsOnDate.Add(trip);
                }
            }

            return tripsOnDate;
        }        
        public List<Trip> GetTripsByMonthAndYear(int year, int month)
        {
            return trips.Where(trip => trip.tripStartTime.Year == year && trip.tripStartTime.Month == month).ToList();
        }
               
        public List<Trip> GetTripsByYear(int year)
        {
            return trips.Where(trip => trip.tripStartTime.Year == year).ToList();
        }

        public double GetFuelPrice()
        {
            return fuelType switch
            {
                FuelType.Benzin => 13.49,
                FuelType.Diesel => 12.29,
                FuelType.Electric => 0.30,
                FuelType.Hybrid => 10.99,
                _ => 0
            };
        }
        //Gemme metoder
        public override string ToString()
        {
            return $"# Car: {carBrand}, {carModel}, {carYear}, {totalMilage}, -, {fuelType}, 01-01-{carYear}, {(gearType == 'A' ? "Automatic" : "Manual")}, {fuelEfficiency}";
        }


        public static Car FromString(string carData)
        {
            // Eksempel: # Car: Toyota, Corolla, 2015, -, -, Petrol, 01-01-2015, Automatic, 15.2
            var parts = carData.Replace("# Car: ", "").Split(", ");
            string brand = parts[0];
            string model = parts[1];
            int year = int.Parse(parts[2]);
            int milage = int.Parse(parts[3]);

            FuelType fuelType = Enum.Parse<FuelType>(parts[5]);
            char gearType = parts[7].ToLower().Contains("auto") ? 'A' : 'M';
            double fuelEfficiency = double.Parse(parts[8]);
            return new Car(brand, model, year, gearType, milage, fuelType, fuelEfficiency);
        }

    }
}
