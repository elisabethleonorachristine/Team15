using CarApp.Specialized;

namespace CarApp.Vehicles
{
    public abstract class Car : IDriveable
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
        
        public bool isCarOn = false;

        public List<Trip> trips;

       

        // Constructor til at initialisere en bilens base
        public Car(string brand, string model, int year, char gear, int milage, FuelType fuel)
        {
            carBrand = brand;
            carModel = model;
            carYear = year;
            gearType = gear;
            totalMilage = milage;
            fuelType = fuel;            
            trips = new List<Trip>();
        }
        
          

        public void MinBil()
        {
            Console.WriteLine($"Min bil: {carBrand} {carModel}, fra {carYear} med gearType: {gearType}, har kørt: {totalMilage} km, og kører på {fuelType} og har en brændstofeffektivitet på {GetEfficiency()} km/L.");
        }

        public void AddMilage(int distance)
        {
            totalMilage += distance;
        }

        public void StartEngine()
        {
            isCarOn = true;
            Console.WriteLine("The car is now turned on.");
        }

        public void StopEngine()
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
                    DinBil.userCar.StartEngine();
                }
                else
                {
                    Console.WriteLine("You need to turn on the car before starting the trip.");
                    return;
                }
            }
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
                trip.PrintTripDetails(GetEfficiency(), literPrice, carBrand);
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
        public bool CanDrive(double km)
        {
            return km <= GetRange();
        }
        public override string ToString()
        {
            return $"# Car: {carBrand}, {carModel}, {carYear}, {totalMilage}, -, {fuelType}, 01-01-{carYear}, {(gearType == 'A' ? "Automatic" : "Manual")}, {GetEfficiency()}";
        }

        public void Drive(double km)
        {
            var trip = new Trip(km);   // hvis du valgte løsning A
            Drive(trip);
        }
        public abstract void Drive(Trip trip);
        public abstract double GetEfficiency();        
        public abstract double GetRange();
        /*
        public virtual void Drive(Trip trip)
        {
            trips.Add(trip);
            AddMilage((int)trip.tripDistance);
            Console.WriteLine($"Du har kørt {trip.tripDistance} km.");

            trip.PrintTripDetails(GetEfficiency(), GetFuelPrice(), carBrand);
        }

        */
        

        public static Car FromString(string carData)
        {
            // Eksempel: # Car: Tesla, Model S, 2020, 50000, -, Electric, 01-01-2020, Automatic, 6.5
            var parts = carData.Replace("# Car: ", "").Split(", ");

            string brand = parts[0];
            string model = parts[1];
            int year = int.Parse(parts[2]);
            int milage = int.Parse(parts[3]);

            FuelType fuelType = Enum.Parse<FuelType>(parts[5]);
            char gearType = parts[7].ToLower().Contains("auto") ? 'A' : 'M';
            double efficiency = double.Parse(parts[8]); // Her ændret navnet

            // Vælg biltype baseret på fuelType
            if (fuelType == FuelType.Electric)
            {
                return new ElectricCar(brand, model, year, gearType, milage, fuelType,
                                       batteryLevel: 25, batteryCapacity: 60,
                                       kmPerCharge: efficiency, chargeTime: 1.5);
            }
            else
            {
                return new FuelCar(brand, model, year, gearType, milage, fuelType,
                                   fuelLevel: 20, tankCapacity: 50, kmPerLiter: efficiency);
            }
        }



    }
}
