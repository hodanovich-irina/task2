using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkLibrary
{
    public class TruckTractor : Transport
    {
        public TruckTractor() { }
        public string Semitrailer { get; set; }
        public double FuelConsumption {get; set;}

       //public TruckTractor(string name, double maxMass,double fuelConsumption) : base(name, maxMass)
       //{
         //   FuelConsumption = fuelConsumption;
       //}
        public TruckTractor(string name, double maxMass , double fuelConsumption,string semitrailer) : base(name, maxMass)
        {
            FuelConsumption = fuelConsumption;
            Semitrailer = semitrailer;
        }
        public override Transport Create()
        {
            return new TruckTractor();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
