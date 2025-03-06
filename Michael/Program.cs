using Microsoft.VisualBasic.FileIO;
using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using Annettes_carapp.bil;


namespace CarApp.Michael
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
            
            Car michaelBil = new CarApp.Michael.Car();
            AnnetteBil annetteBil = new Annettes_carapp.bil.AnnetteBil();

            Console.WriteLine($"Michael har en {michaelBil.carBrand} fra {michaelBil.carYear} med {michaelBil.totalMilage} km.");
            
            Console.WriteLine($"Annette har en {annetteBil.Brand} fra {annetteBil.Year} med {annetteBil.Odometer} km.");
            
            Console.WriteLine($"Du har en {DinBil.userCar.carBrand} fra {DinBil.userCar.carYear} med {DinBil.userCar.totalMilage} km.");
        }
    }
}



    


/*
        Bil bil = new Bil();
        bil.MinBil();

        DinBil binBil = new DinBil();
        binBil.DinBilInfo();
        */


/*
 string carBrand = "Toyota";
 string carModel = "Corolla";
 int carYear = 2020;
 char gearType = 'A';


Console.WriteLine("Bilmærket: " + carBrand);
    Console.WriteLine("Bilmodellen: " + carModel);
    Console.WriteLine("Bilens årgang: " + carYear);
    Console.WriteLine("Hvilken Geartype: " + gearType);
*/
/*
string carBrand;
string carModel;
int carYear;
char gearType;

string fuelType;
double kmPerL;
int milage;
double distance;
*/
/*
class Bil
{
   public string carBrand = "Toyota";
   public string carModel = "Corolla";
   public int carYear = 2010;
   public char gearType = 'A';
   //public string completeCarInfo = $"Min bil: {carBrand} {carModel}, fra {carYear} med gearType:{gearType} ,";

   public void MinBil()
   {
       Console.WriteLine($"Min bil: {carBrand} {carModel}, fra {carYear} med gearType: {gearType}");
      // Console.WriteLine(String.Concat("Dette er min bil: ", carBrand, " ", carModel, " from ", carYear, " with gear type ", gearType));

   }
}
*/
/*
    class DinBil
    {      
        //Hej

        public void DinBilInfo()
        {
            Console.Write("Enter car brand: ");
            string yourCarBrand;
            yourCarBrand = Console.ReadLine();

            Console.Write("Enter car model: ");
            string yourCarModel;
            yourCarModel = Console.ReadLine();

            Console.Write("Which year is the car model?: ");

            int yourCarYear;
            yourCarYear = Convert.ToInt32(Console.ReadLine());
           */
/*
//hvis brugeren skriver bogstaver:

int yourCarYear;
Console.Write("Enter car year: ");
while (!int.TryParse(Console.ReadLine(), out yourCarYear))
{
    Console.Write("Invalid input. Please enter a valid year: ");
}
Console.WriteLine($"You entered year: {yourCarYear}");


string yourCarYear = Console.ReadLine();
int intYourCarYear = int.Parse(yourCarYear);
*/
/*
Console.Write("Which geartype is the car using?: ");
char yourGearType;
yourGearType = Console.ReadLine()[0];

Console.WriteLine($"Min bil: {yourCarBrand} {yourCarModel}, fra {yourCarYear} med gearType: {yourGearType}");
// Console.WriteLine(String.Concat("Your full Car Info: ", yourCarBrand, " ", yourCarModel, " from ", yourCarYear, " with gear type ", yourGearType));

}
}
*/
/*
        //Information entered by user

        Console.Write("Enter car brand: ");            
        carBrand = Console.ReadLine() ;

        Console.Write("Enter car model: ");            
        carModel = Console.ReadLine();

        Console.Write("Which year is the car model? ");            
        carYear = Convert.ToInt32(Console.ReadLine());

        Console.Write("Which geartype is the car using (M for Manual and A for Automatic?: ");            
        gearType = Console.ReadLine()[0];

        Console.Write("What is the cars gass type? (Benzin/Diesel): ");
        fuelType = Console.ReadLine().Trim().ToLower(); ;

        Console.Write("How far can it travel pr. km/L? ");
        kmPerL = Convert.ToDouble(Console.ReadLine());

        Console.Write("What is the current milage on the car? ");
        milage = Convert.ToInt32(Console.ReadLine());
        */
/*
//Information printed by console
Console.WriteLine("\n" + "Car brand: " + carBrand);
Console.WriteLine("Car model: " + carModel);
Console.WriteLine("Car year: " + carYear);
Console.WriteLine("Geartype: " + gearType);
*/
// Console.WriteLine($"Full car info: {carBrand} {carModel}, from {carYear} with gearType: {gearType}, it's gastype is {fuelType} and runs {kmPerL} Km/l, it's current milage is {milage}");
//Console.WriteLine(String.Concat("\n" + "Full Car Info: ", carBrand," ", carModel, " from ", carYear, " with gear type ", gearType));
/*
Console.WriteLine("What your current distance for your travel? ");
distance = Convert.ToDouble(Console.ReadLine());

//double fuelPrice = (fuelType == "benzin") ? 13.49 : 12.29;

double fuelPrice;
if (fuelType == "benzin")
{
    fuelPrice = 13.49;
}
else
{
    fuelPrice = 12.29;
}

double fuelNeeded = (int)Math.Round(distance / kmPerL);

double tripCost = Math.Round(fuelNeeded * fuelPrice,2);


Console.WriteLine("\nFull Car Info:");

// Print header
Console.WriteLine(string.Format("{0,-12} | {1,-12} | {2,-12}",
    "Bilmærke", "Model", "Kilometertal"));

// Seperation Lines
Console.WriteLine(new string('-', 42));

// Print car details
Console.WriteLine(string.Format("{0,-12} | {1,-12} | {2,-12} km",
carBrand.PadRight(12), 
carModel.PadRight(12), 
milage.ToString("N0").PadRight(12)));

int newMilage = milage + (int)Math.Round(distance);

Console.WriteLine($"\nThe fuel needed for you trip is: {fuelNeeded} liters and will cost you {tripCost} kr");
Console.WriteLine($"your milage after the trip will be a total of: {newMilage} km");

*/

