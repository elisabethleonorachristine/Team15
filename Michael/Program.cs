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
        static double distance = 0;
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
                Console.WriteLine("Press 1 for Read Car Details \nPress 2 for Drive \nPress 3 for Calculate Trip Price \nPress 4 for IsPalindrome \nPress 5 for Print Car Detail \nPress 6 Print All Team Car \nPress 7 to Exit");
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
                            CheckCarAviability();
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 3:
                            Console.Clear();
                            double distance = Trip();
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

 

        static void CheckCarAviability()
        {
            if (DinBil.userCar == null)
            {
                Console.WriteLine("No car details available. Please enter car details first (Option 1).");
                return;
            }

            DinBil.userCar.Drive();

        }
        static double Trip()
        {
            
            Console.Write("What is your current travel distance? ");            
            
            while (!double.TryParse(Console.ReadLine(), out distance) || distance < 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                Console.Write("What is your current travel distance? ");
            }
            CalculateTripCost(distance);
            return distance;

        }
        static void CalculateTripCost(double distance)
        {
            if (DinBil.userCar == null)
            {
                Console.WriteLine("No car details available. Please enter car details first (Option 1).");
                return;
            }

            string fuelType = DinBil.userCar.fuelType; // Hent bilens fuelType

            double fuelPrice = (fuelType == "benzin") ? 13.49 : 12.29;
            double kmPerL = 15;

            double fuelNeeded = Math.Round(distance / kmPerL, 2);
            double tripCost = Math.Round(fuelNeeded * fuelPrice, 2);

            Console.WriteLine($"\nFuel needed: {fuelNeeded} L");
            Console.WriteLine($"Total trip cost: {tripCost} kr\n");
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
            
            Car michaelBil = new CarApp.Vehicles.Car();
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
    }
}



