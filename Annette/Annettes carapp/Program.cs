using System.Globalization;

namespace Annettes_carapp
{
    internal class Program
    {
        static string brand;
        static string model;
        static int year;
        static double odometer;
        static double kmPerLiter;
        static double distance;
        static double newDistance;
        
        static void ReadCarDetails()
        {
            Console.Write("\n\nIndtast bilmærke: ");
            brand = Console.ReadLine();

            Console.Write("Indtast model: ");
            model = Console.ReadLine();

            Console.Write("Indtast årgang: ");
            year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Indtast km per liter: ");
            kmPerLiter=Convert.ToDouble(Console.ReadLine());

            Console.Write("Indtast antal kørte km: ");
            odometer = Convert.ToDouble(Console.ReadLine());

            
        }

        static void Drive()
        {
            bool isEngineOn = false;
            Console.WriteLine("\nHar du tændt bilen (ja elller nej)?");
            string motor = Console.ReadLine().ToLower();
            if (motor=="ja")
            {
                isEngineOn = true;
                Console.WriteLine("\nHvor langt har du kørt?");
                distance = Convert.ToDouble(Console.ReadLine());
                newDistance = Convert.ToDouble(odometer+distance);
                Console.WriteLine($"\nBilens odometer er nu på: {newDistance}");
            }
            else
            {
                Console.WriteLine("\nTænd bilen");
            }
        }

        static void CalculateTripPrice()
        {
            Console.Write("\nIndtast brændstoftype (benzin eller diesel: ");
            String brændstoftype = Console.ReadLine().ToLower();

            //brændstofpriser
            double fuelNeeded = distance / kmPerLiter;
            double benzinpris = 13.49;
            double dieselpris = 12.29;

            //Beregning af turpris baseret på brændstoftype
            double tripCost;
            if (brændstoftype == "diesel")
            {
                tripCost = fuelNeeded * dieselpris;
            }
            else
            {
                tripCost = fuelNeeded * benzinpris;
            }
            Console.WriteLine($"\nBrændstofomkostninger for turen på {distance}km: {tripCost}kr");
        }

        /*static void IsPalindrome()
        {
            Console.WriteLine($"\nDit odometer er på: {odometer}");
            string kmStr=odometer.ToString();
            if
                km
        }*/

        static void printCardetails()
        {
            Console.WriteLine($"\nDette er din bil: \nBilmærke: {brand} \nBilmodel: {model} \nÅrgang: {year} \nKmperliter: {kmPerLiter} \nOdometer: {odometer}\n");
            Console.WriteLine($"Din bil er en {brand} {model} fra {year} og har kørt {odometer} km");
        }
        static void Main(string[] args)
        {
                 
            int choice;
            do
            {
                Console.WriteLine("\n\nMENU:");
                Console.WriteLine("1: Read Car Details");
                Console.WriteLine("2: Drive");
                Console.WriteLine("3: Calculate Trip Price");
                Console.WriteLine("4: IsPalindrome");
                Console.WriteLine("5: Print Car Details");
                Console.WriteLine("6: Print All Team Cars");
                Console.WriteLine("7: Afslut programmet");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ReadCarDetails();
                        break;
                    case 2:
                        Drive();
                        break;
                    case 3:
                        CalculateTripPrice();
                        break;
                    /*case 4:
                        IsPalindrome();
                        break;*/
                    case 5:
                        printCardetails();
                        break;
                }
            
            }
            while (choice != 7);
            
            /*//Bilmodel
            Console.Write("Indtast bilmærke: ");
            String brand = Console.ReadLine();

            Console.Write("Indtast model: ");
            String model = Console.ReadLine();

            Console.Write("Indtast årgang: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Indtast geartype (A for automatisk, M for manuel): ");
            Char geartype = Console.ReadLine()[0];

            Console.WriteLine("\nDette er din bil");
            Console.WriteLine("Bilmærke: " + brand);
            Console.WriteLine("Bilmodel: " + model);
            Console.WriteLine("Årgang: " + year);
            Console.WriteLine("Gear: " + geartype);

            Console.WriteLine($"Din bil er en {brand} {model} fra {year} og har geartypen {geartype}");

            //Info om brændstof og kilometer
            Console.Write("\nIndtast brændstoftype: ");
            String brændstoftype = Console.ReadLine().ToLower();

            Console.Write("Indtast km per liter: ");
            int kmperliter = Convert.ToInt32(Console.ReadLine());

            Console.Write("Kilometerstand: ");
            int kilometerstand = Convert.ToInt32(Console.ReadLine());

            //Ønsket distance
            Console.Write("Ønsket køreturs distance: ");
            int distance = Convert.ToInt32(Console.ReadLine());

            //Brændstofpriser
            double fuelNeeded = distance / kmperliter;
            double benzinpris = 13.49;
            double dieselpris = 12.29;

            //Beregning af turpris baseret på brændstoftype
            double tripCost;
            if (brændstoftype == "diesel")
            {
                tripCost = fuelNeeded * dieselpris;
            }
            else
            {
                tripCost = fuelNeeded * benzinpris;
            }

            //Opdateret kilometerstand
            int nyKilometerstand = kilometerstand + distance;

            //Udskriv bilens oplysninger
            Console.WriteLine("\nDette er din info om antal kørte kilometer og brændstofomkostninger for køreturen");
            Console.WriteLine("Brændstoftype: " + brændstoftype);
            Console.WriteLine("Kilometerstand før planlagt tur: " + kilometerstand + "km");
            Console.WriteLine("Distancen på ønsket tur: " + distance + "km");
            Console.WriteLine("Ny kilometerstand: " + nyKilometerstand + "km");
            Console.WriteLine("Brændstofomkostninger for turen: " + tripCost + "kr");

            string tabel = String.Format("\n{0, -14}|{1, -14}|{2, -14}", "Bilmærke", "Model", "Kilometerstand");
            string tabel1 = String.Format("{0, -14}|{1, -14}|{2, -14}", brand, model, kilometerstand);
            Console.WriteLine(tabel);
            Console.WriteLine(tabel1);

            string strFormat = String.Format("\nBrændstofudgifterne for {0} km er {1}kr", distance, tripCost);
            Console.WriteLine(strFormat);

            Console.ReadLine();*/
        }
    }
}
