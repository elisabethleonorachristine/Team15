using Microsoft.VisualBasic.FileIO;
using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

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

        static void Main(string[] args)
        {
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
            string carBrand;
            string carModel;
            int carYear;
            char gearType;

            string fuelType;
            double kmPerL;
            int milage;
            double distance;
            

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

            /*
            //Information printed by console
            Console.WriteLine("\n" + "Car brand: " + carBrand);
            Console.WriteLine("Car model: " + carModel);
            Console.WriteLine("Car year: " + carYear);
            Console.WriteLine("Geartype: " + gearType);
            */
           // Console.WriteLine($"Full car info: {carBrand} {carModel}, from {carYear} with gearType: {gearType}, it's gastype is {fuelType} and runs {kmPerL} Km/l, it's current milage is {milage}");
            //Console.WriteLine(String.Concat("\n" + "Full Car Info: ", carBrand," ", carModel, " from ", carYear, " with gear type ", gearType));

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

            /*
            Console.WriteLine("Your gass consumption for your trip will be: " + fuelNeeded + " Liter");
            Console.WriteLine("The price for your trip is: " + tripCost + " kr");
            */


            //Console.WriteLine($"\n Full car info: {carBrand} {carModel}, from {carYear} with gearType: {gearType}, it's gastype is {fuelType} and runs {kmPerL} Km/l, it's current milage is {milage}");
            /*
             Console.WriteLine("\nFull Car Info:");
             Console.WriteLine(string.Format("{0,-12} {1,-12} {2,-6} {3,-10} {4,-10} {5,8} {6,10}",
                 "Brand", "Model", "Year", "GearType", "FuelType", "Km/L", "Milage"));
             // Seperation Lines
             Console.WriteLine(new string('-', 60)); 

             Console.WriteLine(string.Format("{0,-12} {1,-12} {2,-6} {3,-10} {4,-10} {5,8} {6,10}",
                 carBrand.PadRight(12), carModel.PadRight(12), carYear.ToString().PadRight(6),
                 gearType.ToString().PadRight(10), fuelType.PadRight(10),
                 kmPerL.ToString("0.00").PadLeft(8), milage.ToString().PadLeft(10)));
            */
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
            

            Console.ReadLine();
        }
    }

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
}
