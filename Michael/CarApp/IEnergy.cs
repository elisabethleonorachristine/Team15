using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarApp.Specialized;


namespace CarApp
{
    public interface IEnergy
    {
        double EnergyLevel { get; }
        double MaxEnergy { get; }
        void Refill(double amount);
        void UseEnergy(double kilometers);
    }
}
