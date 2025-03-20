using Microsoft.VisualBasic.FileIO;
using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using CarApp.Vehicles; 
using CarApp.TeamCars;



namespace CarApp
{
    /*
    Applikation: Et program, der hjælper brugeren med en opgave.
    Instruktion: En enkelt kommando til computeren. f.eks: Console.WriteLine("Hej verden!");
    Sætning(Statement): En fuld programmeringslinje, der afsluttes med ; f.eks int sum = 2+4;
    Kodeblok: En gruppe af statements inden for { }, der udføres sammen.
    */
    
    

    class Program
    {
        
        
        static Car defaultAudi = new Car("Audi", "TT", 2022, 'A', 1000, Car.FuelType.Benzin, 15)
        {
            trips = new List<Trip>()
            {
             new Trip(30, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-5).AddMinutes(20)),
             new Trip(50, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-2).AddMinutes(35)),
             new Trip(100, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1).AddMinutes(60))
            }
        };

        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {

            char Choice;
            int MenuOption;

            do
            {
                Console.WriteLine("Press 1 for Read Car Details \nPress 2 for Trip \nPress 3 for Show Trips \nPress 4 for IsPalindrome \nPress 5 for Print Car Detail \nPress 6 Print All Team Car \nPress 7 for Show Trips By Date \nPress 8 to Exit");
                if (int.TryParse(Console.ReadLine(), out MenuOption))
                {
                    switch (MenuOption)
                    {
                        case 1:
                            Console.Clear();
                            DinBil dinBil = new DinBil();
                            dinBil.DinBilInfo();
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 2:
                            Console.Clear();
                            StartTrip();
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 3:
                            Console.Clear();
                            ShowAllTrips();
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 4:
                            Console.Clear();
                            Console.Write("Enter the odometer reading (km): ");
                            if (int.TryParse(Console.ReadLine(), out int km))
                            {
                                IsPalindrome(km); // Kald metoden med km som argument (den printer selv resultatet)
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 5:
                            Console.Clear();
                            if (DinBil.userCar != null)
                            {
                                DinBil.userCar.MinBil(); // Printer bilens info
                            }
                            else
                            {
                                Console.WriteLine("No car details available. Please enter car details first (Option 1).");
                            }
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 6:
                            Console.Clear();
                            ShowAllCars();
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 7:
                            Console.Clear();
                            ShowTripsByDate();
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 8:
                            Console.WriteLine("Exiting the program...");
                            return;  // Stopper programmet

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                // Spørger om brugeren vil fortsætte
                Console.WriteLine("Please Enter Y to continue, any other key to terminate");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || Char.ToUpper(input[0])!= 'Y')
                {
                   break;
                }
                
                Console.Clear();
            }
            while (true);
        }


        static void StartTrip()
        {
            if (DinBil.userCar == null)
            {
                Console.WriteLine("No car details available. Please enter car details first (Option 1).");
                return;
            }
            DinBil.userCar.IsCarTurnedOn();

            // Indhent turens distance
            Console.Write("Enter the distance you want to drive (km): ");
            if (!double.TryParse(Console.ReadLine(), out double distance) || distance <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }
            Console.Clear();
            // Registrer starttidspunkt
            DateTime startTime = DateTime.Now;
            Console.WriteLine("Press any key to stop the trip...");
            Console.ReadKey();

            // Registrer sluttidspunkt
            DateTime endTime = DateTime.Now;

            // Opret turen og send den til bilen
            Trip newTrip = new Trip(distance, startTime, endTime);
            DinBil.userCar.Drive(newTrip);
        }

        static void ShowAllTrips()
        {
            if (DinBil.userCar == null)
            {
                Console.WriteLine("No car details available. Please enter car details first (Option 1).");
                return;
            }

            DinBil.userCar.PrintAllTrips(DinBil.userCar.GetFuelPrice()); 
        }
        


        static bool IsPalindrome(int km)
        {
            int original = km;  // Gem det originale tal
            int reversed = 0;

            while (km > 0)
            {
                int digit = km % 10; // Hent sidste ciffer
                reversed = reversed * 10 + digit; // Byg det omvendte tal
                km /= 10; // Fjern sidste ciffer fra originalt tal
            }

            bool isPalin = original == reversed; // Sammenlign det omvendte med originalen

            // Udskriv resultatet
            if (isPalin)
            {
                Console.WriteLine($"{original} is a palindrome!");
                
            }
            else
            {
                Console.WriteLine($"{original} is NOT a palindrome.");
                
            }

            return isPalin;
        }
        static void ShowAllCars()
        {
            
            Car michaelBil = defaultAudi;
            AnnetteBil annetteBil = new TeamCars.AnnetteBil();

            Console.WriteLine($"Michael har en {michaelBil.carBrand} fra {michaelBil.carYear} med {michaelBil.totalMilage} km.");
            
            Console.WriteLine($"Annette har en {annetteBil.Brand} fra {annetteBil.Year} med {annetteBil.Odometer} km.");
            
            if(DinBil.userCar != null ) 
            {
                Console.WriteLine($"Du har en {DinBil.userCar.carBrand} fra {DinBil.userCar.carYear} med {DinBil.userCar.totalMilage} km.");

            }
            else
            {
                Console.WriteLine("Du har ikke indtastet din bil endnu.");
            }
        }
        static void ShowTripsByDate()
        {
            Console.Write("Enter a date (yyyy, yyyy-MM, or yyyy-MM-dd) to see trips: ");
            string userInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Invalid input. Please enter a valid date format.");
                return;
            }

            // Brug defaultCar hvis DinBil.userCar er null
            Car carToCheck = DinBil.userCar ?? defaultAudi;

            List<Trip> filteredTrips = new List<Trip>();

            // Prøv at parse til år, måned eller dato
            if (DateTime.TryParseExact(userInput, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime exactDate))
            {
                // Brugeren har skrevet en **præcis dato**, filtrer kun på den dag
                filteredTrips = carToCheck.GetTripsByDate(exactDate);
            }
            else if (DateTime.TryParseExact(userInput, "yyyy-MM", null, System.Globalization.DateTimeStyles.None, out DateTime monthYear))
            {
                // Brugeren har skrevet en **måned og år**, find alle ture i den måned
                filteredTrips = carToCheck.GetTripsByMonthAndYear(monthYear.Year, monthYear.Month);
            }
            else if (DateTime.TryParseExact(userInput, "yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime year))
            {
                // Brugeren har skrevet et **år**, find alle ture i det år
                filteredTrips = carToCheck.GetTripsByYear(year.Year);
            }
            else
            {
                Console.WriteLine("Invalid date format. Please use yyyy, yyyy-MM, or yyyy-MM-dd.");
                return;
            }

            // Vis resultaterne
            if (filteredTrips.Count == 0)
            {
                Console.WriteLine($"No trips found matching '{userInput}'.");
            }
            else
            {
                Console.WriteLine($"Trips for '{userInput}':");
                foreach (Trip trip in filteredTrips)
                {
                    trip.PrintTripDetails(carToCheck.fuelEfficiency, carToCheck.GetFuelPrice());
                }
            }
        }

    }
}



