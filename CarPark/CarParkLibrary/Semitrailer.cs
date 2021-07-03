using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkLibrary
{
    public class Semitrailer : Transport, ISemitrailer
    {
        public string TypeOfGoods { get; set; }
        public string StorageConditions { get; set; }
        public double Mass { get; set; }
        public double MassOfGoods { get; set; }

        //public Semitrailer() { }
        public Semitrailer(string name, double maxMass, string typeOfGoods, string storageConditions, double mass, double massOfGoods) : base(name, maxMass)
        {
            TypeOfGoods = typeOfGoods;
            StorageConditions = storageConditions;
            Mass = mass;
            MassOfGoods = massOfGoods;
        }
        
        public Semitrailer()
        {
        }
        public double AvailableVolume()
        { 
            return MaxMass - Mass -  MassOfGoods; 
        }
        public override Transport Create()
        {
            return new Semitrailer();
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
