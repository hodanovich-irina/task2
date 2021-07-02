using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarParkLibrary;

namespace CarParkLibrary.DataWork
{
    public class ListWork
    {
        public List<Semitrailer> FindSemitrailerByType(string type)
        {
            List<Semitrailer> semitrailers = new List<Semitrailer>();

            var x = SaxParser.SaxParsing(@"../../CarPark.xml");
            foreach (var x1 in x) 
            {
                if (type == "refrigerator" && x1 is Refrigerator)
                    semitrailers.Add((Semitrailer)x1);
                if (type == "tank truck" && x1 is TankTruck)
                    semitrailers.Add((TankTruck)x1);
            }
            return semitrailers;
        }
        public List<Semitrailer> FindSemitrailerByCharacteristics(string name, double maxMass, string typeOfGoods, string storageConditions, double mass, double massOfGoods)
        {
            List<Semitrailer> semitrailers = new List<Semitrailer>();
            List<Semitrailer> semitrailers2 = new List<Semitrailer>();

            var x = SaxParser.SaxParsing(@"../../CarPark.xml");
            foreach (var x1 in x)
            {
                if (x1 is Semitrailer && x1.Name == name && x1.MaxMass == maxMass)
                    semitrailers.Add((Semitrailer)x1);
            }
            foreach (var v in semitrailers)
            {
                if (v.Name == name && v.MaxMass == maxMass && v.TypeOfGoods == typeOfGoods && v.StorageConditions == storageConditions && v.Mass == mass && v.MassOfGoods == massOfGoods)
                    semitrailers2.Add(v);
            }
            return semitrailers2;

        }
    }
}
