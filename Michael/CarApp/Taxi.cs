using CarApp.Vehicles;

namespace CarApp.Specialized
{
    public class Taxi
    {
        private readonly Car _car;        // den konkrete bil
        private readonly IEnergy _energy;     // bruges kun til at tanke
        private bool _meterStarted;
        private DateTime _meterStartTime;

        public double StartPrice { get; }
        public double PricePerKm { get; }
        public double PricePerMinute { get; }

        public Taxi(Car car, IEnergy energy, double startPrice = 39, double pricePerKm = 12, double pricePerMinute = 6)
        {
            _car = car;
            _energy = energy;
            StartPrice = startPrice;
            PricePerKm = pricePerKm;
            PricePerMinute = pricePerMinute;
        }


        public void StartMeter()
        {
            if (_meterStarted)
            {
                Console.WriteLine("Meter already started!");
                return;
            }

            _car.StartEngine();
            _meterStartTime = DateTime.Now;
            _meterStarted = true;
            Console.WriteLine("Meter started...");
        }

        public void StopMeter(double drivenKm)
        {
            if (!_meterStarted)
            {
                Console.WriteLine("Meter has not been started!");
                return;
            }

            var duration = DateTime.Now - _meterStartTime;
            _meterStarted = false;
            _car.StopEngine();

            double timeMinutes = duration.TotalMinutes;
            double total = StartPrice +
                           (drivenKm * PricePerKm) +
                           (timeMinutes * PricePerMinute);

            Console.WriteLine("\n--- TAXI FARE ---");
            Console.WriteLine($"Startpris: {StartPrice} kr");
            Console.WriteLine($"Distance: {drivenKm} km x {PricePerKm} kr = {(drivenKm * PricePerKm):F2} kr");
            Console.WriteLine($"Tid: {duration.Minutes} min {duration.Seconds} sek = " +
                              $"{timeMinutes:F2} min x {PricePerMinute} kr = {(timeMinutes * PricePerMinute):F2} kr");
            Console.WriteLine($"Total pris: {total:F2} kr\n");
        }


        public void DriveTrip(double km)
        {
            if (!_car.CanDrive(km))
            {
                Console.WriteLine("Bilen har ikke rækkevidde nok til turen.");
                return;
            }

            StartMeter();

            Console.WriteLine("Taxatur i gang... tryk en tast for at afslutte turen.");
            Console.ReadKey();

            var trip = new Trip(km);      
            _car.Drive(trip);             // FuelCar/ElectricCar håndterer energi

            StopMeter(km);
            new DataHandler("cars.txt").SaveSingleCar(_car);
        }

        

        public void RefuelTaxi(double amount) => _energy.Refill(amount);
    }
}
