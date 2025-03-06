namespace CarApp.Michael
{
    public class Car // Skabelon for bilen
    {
        
        public string carBrand { get; set; }
        public string carModel { get; set; }
        public int carYear { get; set; }
        public char gearType { get; set; }
        public int totalMilage { get; private set; }
        public string fuelType { get; set; }
        public bool isCarOn { get; private set; }

        // Constructor til at initialisere en bil
        public Car(string brand, string model, int year, char gear, int milage, string fuel)
        {
            carBrand = brand;
            carModel = model;
            carYear = year;
            gearType = gear;
            totalMilage = milage;
            fuelType = fuel;
        }
        
        public Car()
        {
            carBrand = "Audi";
            carModel = "TT";
            carYear = 2022;
            totalMilage = 1000;
            fuelType = "benzin";  
        }
        
        public void MinBil()
        {
            Console.WriteLine($"Min bil: {carBrand} {carModel}, fra {carYear} med gearType: {gearType}, har kørt: {totalMilage} km, og kører på {fuelType}.");
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
    }
}
