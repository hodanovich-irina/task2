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
        public List<TruckTractor> FuelConsumption() 
        {
            List<TruckTractor> truckTractors = new List<TruckTractor>();
            List<Semitrailer> semitrailers = new List<Semitrailer>();
            foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
            {
                if (v1 is TruckTractor)
                    truckTractors.Add((TruckTractor)v1);
                if (v1 is Semitrailer)
                    semitrailers.Add((Semitrailer)v1);
            }
            foreach (var v in truckTractors) 
            {
                foreach (var s in semitrailers)
                    if (v.Semitrailer == s.ToString())
                        v.FuelConsumption = v.FuelConsumption + ((s.MaxMass - s.AvailableVolume()) / 5);
            }
            return truckTractors;
        }
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
        public Dictionary<string, string> FindСouplingByTypeOfGoods(string typeOfGoods)
        {
            List<TruckTractor> truckTractors = new List<TruckTractor>();
            List<Semitrailer> semitrailers = new List<Semitrailer>();
            List<TruckTractor> coupling = new List<TruckTractor>();
            Dictionary<string, string> coupling1 = new Dictionary<string, string>();

            var x = SaxParser.SaxParsing(@"../../CarPark.xml");
            foreach (var x1 in x)
            {
                if (x1 is TruckTractor)
                    truckTractors.Add((TruckTractor)x1);
                if (x1 is Semitrailer)
                    semitrailers.Add((Semitrailer)x1);

            }
            foreach (var x1 in semitrailers)
            {
                foreach (var y1 in truckTractors)
                    if (x1.TypeOfGoods == typeOfGoods && y1.Semitrailer == x1.ToString())
                        coupling1.Add(y1.ToString(), y1.Semitrailer);

            }
            return coupling1;

        }

        //public Dictionary<string, string> FindСouplingForAddGoods()
        public List<TruckTractor> FindСouplingForAddGoods()
        {
            List<TruckTractor> truckTractors = new List<TruckTractor>();
            List<Semitrailer> semitrailers = new List<Semitrailer>();
            List<TruckTractor> coupling = new List<TruckTractor>();
            //Dictionary<string, string> coupling1 = new Dictionary<string, string>();

            var x = SaxParser.SaxParsing(@"../../CarPark.xml");
            foreach (var x1 in x)
            {
                if (x1 is TruckTractor)
                    truckTractors.Add((TruckTractor)x1);
                if (x1 is Semitrailer)
                    semitrailers.Add((Semitrailer)x1);

            }
            foreach (var x1 in semitrailers)
            {
                foreach (var y1 in truckTractors)
                    if (x1.AvailableVolume() > 0 && y1.Semitrailer == x1.ToString())
                        coupling.Add(y1);
                        //coupling1.Add(y1.ToString(), y1.Semitrailer);
            }
            //return coupling1;
            return coupling;

        }

        public double OpportunitiesOfLogisticiansAddGood(TruckTractor truckTractor, string typeOfGoods, double mass)
        {
            Semitrailer semitrailer = new Semitrailer();
            foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                if (v1 is Semitrailer && v1.ToString() == truckTractor.Semitrailer)
                    semitrailer = (Semitrailer)v1;
            if (semitrailer.AvailableVolume() >= mass && semitrailer.TypeOfGoods == typeOfGoods)
                semitrailer.MassOfGoods = semitrailer.MassOfGoods + mass;
            return semitrailer.MassOfGoods;
        }

        public double OpportunitiesOfLogisticiansFullAddGood(TruckTractor truckTractor, string typeOfGoods)
        {
            Semitrailer semitrailer = new Semitrailer();
            foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                if (v1 is Semitrailer && v1.ToString() == truckTractor.Semitrailer)
                    semitrailer = (Semitrailer)v1;
            if (semitrailer.AvailableVolume() > 0 && semitrailer.TypeOfGoods == typeOfGoods)
                semitrailer.MassOfGoods = semitrailer.MassOfGoods + semitrailer.AvailableVolume();
            return semitrailer.MassOfGoods;
        }

        public double OpportunitiesOfLogisticiansMinusGood(TruckTractor truckTractor, string typeOfGoods, double mass)
        {
            Semitrailer semitrailer = new Semitrailer();
            foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                if (v1 is Semitrailer && v1.ToString() == truckTractor.Semitrailer)
                    semitrailer = (Semitrailer)v1;
            if (semitrailer.MassOfGoods - mass >= 0 && semitrailer.TypeOfGoods == typeOfGoods)
                semitrailer.MassOfGoods = semitrailer.MassOfGoods - mass;
            return semitrailer.MassOfGoods;
        }
        public double OpportunitiesOfLogisticiansMinusAllGood(TruckTractor truckTractor, string typeOfGoods)
        {
            Semitrailer semitrailer = new Semitrailer();
            foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                if (v1 is Semitrailer && v1.ToString() == truckTractor.Semitrailer)
                    semitrailer = (Semitrailer)v1;
            if (semitrailer.MassOfGoods > 0 && semitrailer.TypeOfGoods == typeOfGoods)
                semitrailer.MassOfGoods = 0;
            return semitrailer.MassOfGoods;
        }
        public TruckTractor ReplaceSemitrailer(TruckTractor truckTractor, Semitrailer semitrailer)
        {
            foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                if (v1 is TruckTractor && v1 == truckTractor)
                    truckTractor = (TruckTractor)v1;
            truckTractor.Semitrailer = semitrailer.ToString();
            return truckTractor;
        }
        public TruckTractor DeleteSemitrailer(TruckTractor truckTractor)
        {
            foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                if (v1 is TruckTractor && v1 == truckTractor)
                    truckTractor = (TruckTractor)v1;
            truckTractor.Semitrailer = "";
            return truckTractor;
        }
    }
}
