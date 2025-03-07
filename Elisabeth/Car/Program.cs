using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

namespace Car
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Car userCar = null;
            while (true)
            {
                ShowMenu(ref userCar);
            }


        }

        public static void ShowMenu(ref Car userCar)
        {



            Console.WriteLine("Choose an action to take:\n" +
                "1. Read Car Details\n" +
                "2. Print Car Details\n" +
                "3. Drive\n" +
                "4. Calculate Trip Price\n" +
                "5. Is the Odometer a Palindrome?");

            string menuChoice = Console.ReadLine();


            if (menuChoice == "1")
            {

                Car.ReadCarDetails(out userCar);
            }

            else if (menuChoice == "2")
            {
                userCar.PrintCarDetails();
            }
            else if (menuChoice == "3")
            {
                userCar.Drive();
            }
            else if (menuChoice == "4")
            {
                userCar.CalculateTripPrice();
            }
            else if (menuChoice == "5")
            {

                IsPalindrome(userCar.Odometer);

            }
            else if (menuChoice == "6")
            {
                Environment.Exit(0);
            }



            static void IsPalindrome(double odometer)
            {
                string odoString = odometer.ToString();
                string odoReverse = new string(odoString.Reverse().ToArray());
                if (odoReverse == odoString)
                {
                    Console.WriteLine("Odometeret er et palindrom");
                    Console.WriteLine(odometer);
                }
                else
                {
                    Console.WriteLine("Odometeret er ikke et palindrom");
                }
            }
        }
    }
}       
            
        
   

