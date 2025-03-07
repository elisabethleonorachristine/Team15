using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annettes_carapp.bil
{
    public class AnnetteBil
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Odometer { get; set; }
        public double KmPerLiter { get; set; }

        public AnnetteBil()
        {
            Brand = "Toyota";
            Model = "Yaris";
            Year = 2018;
            Odometer = 50000;
            KmPerLiter = 20.5;
        }

        public void PrintCarDetails()
        {
            Console.WriteLine($"\nAnnettes bil: {Brand} {Model} ({Year}) med {Odometer} km kørt.");
        }
    }
}
