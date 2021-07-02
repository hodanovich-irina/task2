using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkLibrary
{
    public enum ViewFuel
    {
        AI98 = 1,
        AI95,
        AI92,
        AI80,
        Diesel,
        Gas
    }
    public class TankTruck : Semitrailer
    {            
        public ViewFuel ViewFuel { get; set; }
        public TankTruck(string name, double maxMass, string typeOfGoods, string storageConditions, double mass, double massOfGoods, ViewFuel viewFuel) : base(name, maxMass, typeOfGoods, storageConditions, massOfGoods, mass)
        {
            ViewFuel = viewFuel;
        }

        public TankTruck()
        {
        }

        public override Transport Create()
        {
            return new TankTruck();
        }


        public override bool Equals(object obj)
        {
            return obj is TankTruck truck &&
                   base.Equals(obj) &&
                   ViewFuel == truck.ViewFuel;
        }

        public override int GetHashCode()
        {
            int hashCode = -2084488606;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + ViewFuel.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
