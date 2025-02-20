namespace Annettes_carapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bilmodel
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

            Console.ReadLine();
        }
    }
}
