using System.ComponentModel.Design;
using CarApp;

internal class Program
{
    static string brand;
    static string model;
    static string brændstofstype;
    static char geartype;
    static double kmPerLiter;
    static int year;
    static int kmStand; // a.k.a odomoter gad ikke til at ændre det :P 
    static bool isEngineOn = false;


    private static void Main(string[] args)
    {
        bool start = true;
        Car myCar = null;

        while (start)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Opret en ny bil");
            Console.WriteLine("2. Vis bilens oplysninger");
            Console.WriteLine("3. Kør en tur");
            Console.WriteLine("4. Afslut program");

            string valg = Console.ReadLine();
            switch (valg)
            {
                case "1":
                    //Jeg anvender konstruktøren og opretter en bil
                    myCar = new Car("Toyota", "Corolla", "Benzin", 'm', 12.0, 2001,1000, true);
                    Console.WriteLine("En ny bil er blevet oprettet!");
                    break;
                case "2":
                    if (myCar != null)
                    {
                        myCar.PrintCarDetails();
                    }
                    else {
                        Console.WriteLine("Der er ikke oprettet nogen bil");
                    } 
                    break;
                case "3":
                    if (myCar != null)
                    {
                        StartDriving(myCar);
                    }
                    else
                    {
                        Console.WriteLine("Du har ikke oprettet en bil. Opret en bil først");
                    }
                    break;
                case "4":
                    start = false;
                    Console.WriteLine("Afslut program");
                    break;

                default:
                    Console.WriteLine("Ugyldigt valg. Prøv igen.");
                    break;
            }
        }
    }

    private static void StartDriving(Car myCar)
    {
        Console.WriteLine("\nVil du køre en tur?");
        Console.WriteLine("1. Ja");
        Console.WriteLine("2. Nej");
        string kørValg = Console.ReadLine();
        if (kørValg == "1")
        {
            if (!myCar.getisEngineOn()) {
                myCar.StartEngine();
            }
            Console.WriteLine("Hvor langt vil du køre?");
            double distance = Convert.ToDouble(Console.ReadLine());
            myCar.Drive(distance);
            
        }
        else
        {
            Console.WriteLine("Det er vel også bedre for miljøet :P");
        }
    }
    public static bool IsPalindrome(int km)
    {
        string kmString = km.ToString();
        int length = kmString.Length;

        for (int i = 0; i < length / 2; i++)
        {
            if (kmString[i] != kmString[length - i - 1])
            {
                return false;
            }
        }
        return true;
    }
}

















