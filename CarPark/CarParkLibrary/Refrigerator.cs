using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkLibrary
{

    public class Refrigerator : Semitrailer
    {
        public Refrigerator()
        {
        }
        
        public Refrigerator(string name, double maxMass, string typeOfGoods, string storageConditions, double mass, double massOfGoods) 
            : base(name, maxMass, typeOfGoods, storageConditions, mass, massOfGoods)
        {
        }

        public override Transport Create()
        {
            return new Refrigerator();
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
