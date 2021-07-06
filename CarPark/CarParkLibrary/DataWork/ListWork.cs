using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarParkLibrary;

namespace CarParkLibrary.DataWork
{
    /// <summary>
    /// Class for work with collections of object
    /// </summary>
    public class ListWork
    {
        /// <summary>
        /// Calculation of fuel consumption
        /// </summary>
        /// <returns>collections of truck tractor</returns>
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
        /// <summary>
        /// Method for finding a semi-trailer by type
        /// </summary>
        /// <param name="type">type of semi-trailer</param>
        /// <returns>collections of semi-trailers</returns>
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
        /// <summary>
        /// Method for finding a semi-trailer by characteristics
        /// </summary>
        /// <param name="name">brand of transport</param>
        /// <param name="maxMass">Lifting capacity</param>
        /// <param name="typeOfGoods">type of goods</param>
        /// <param name="storageConditions">storage conditions</param>
        /// <param name="mass">busy weight</param>
        /// <param name="massOfGoods">mass of goods</param>
        /// <returns>collections of semi-trailers</returns>
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
        /// <summary>
        /// Method for find coupling by type of goods
        /// </summary>
        /// <param name="typeOfGoods">type of goods</param>
        /// <returns>dictionary</returns>
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

        
        /// <summary>
        /// Method for find coupling for add goods
        /// </summary>
        /// <returns>collections of truck tractor</returns>
        public Dictionary<string, string> FindСouplingForAddGoods()
        {
            List<TruckTractor> truckTractors = new List<TruckTractor>();
            List<Transport> transports = new List<Transport>();
            List<Semitrailer> semitrailers = new List<Semitrailer>();
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
                    if (x1.AvailableVolume() > 0 && y1.Semitrailer == x1.ToString())
                        coupling1.Add(y1.ToString(), y1.Semitrailer);
            }
            return coupling1;

        }
        /// <summary>
        /// Inner class for logistic methods
        /// </summary>
        public class OpportunitiesOfLogisticians
        {
            /// <summary>
            /// Method for add good in semitrailer
            /// </summary>
            /// <param name="truckTractor">truck tractor</param>
            /// <param name="typeOfGoods">type of goods</param>
            /// <param name="mass">added mass</param>
            /// <param name="pathForSaveChange">path for save change</param>
            /// <returns>new mass</returns>
            public double OpportunitiesOfLogisticiansAddGood(TruckTractor truckTractor, string typeOfGoods, double mass, string pathForSaveChange)
            {
                List<Transport> transports = new List<Transport>();

                Semitrailer semitrailer = new Semitrailer();
                foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                    if (v1 is Semitrailer && v1.ToString() == truckTractor.Semitrailer)
                        semitrailer = (Semitrailer)v1;
                if (semitrailer.AvailableVolume() >= mass && semitrailer.TypeOfGoods == typeOfGoods)
                    semitrailer.MassOfGoods = semitrailer.MassOfGoods + mass;
                foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                {
                    if (v1 is Semitrailer && v1.ToString() == truckTractor.Semitrailer)
                        transports.Add((Transport)semitrailer);
                    else
                        transports.Add(v1);
                }
                SaxParser.AddInXml(transports, pathForSaveChange);
                return semitrailer.MassOfGoods;
            }
            /// <summary>
            ///  Method for add good in full semitrailer
            /// </summary>
            /// <param name="truckTractor">truck tractor</param>
            /// <param name="typeOfGoods">type of goods</param>
            /// <param name="pathForSaveChange">path for save change</param>
            /// <returns>new mass</returns>
            public double OpportunitiesOfLogisticiansFullAddGood(TruckTractor truckTractor, string typeOfGoods, string pathForSaveChange)
            {
                List<Transport> transports = new List<Transport>();

                Semitrailer semitrailer = new Semitrailer();
                foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                    if (v1 is Semitrailer && v1.ToString() == truckTractor.Semitrailer)
                        semitrailer = (Semitrailer)v1;
                if (semitrailer.AvailableVolume() > 0 && semitrailer.TypeOfGoods == typeOfGoods)
                    semitrailer.MassOfGoods = semitrailer.MassOfGoods + semitrailer.AvailableVolume();
                foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                {
                    if (v1 is Semitrailer && v1.ToString() == truckTractor.Semitrailer)
                        transports.Add((Transport)semitrailer);
                    else
                        transports.Add(v1);
                }
                SaxParser.AddInXml(transports, pathForSaveChange);
                return semitrailer.MassOfGoods;
            }

            /// <summary>
            /// method for unloading goods
            /// </summary>
            /// <param name="truckTractor">truck tractor</param>
            /// <param name="typeOfGoods">type of goods</param>
            /// <param name="mass">added mass</param>
            /// <param name="pathForSaveChange">path for save change</param>
            /// <returns>new mass</returns>
            public double OpportunitiesOfLogisticiansMinusGood(TruckTractor truckTractor, string typeOfGoods, double mass, string pathForSaveChange)
            {
                List<Transport> transports = new List<Transport>();

                Semitrailer semitrailer = new Semitrailer();
                foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                    if (v1 is Semitrailer && v1.ToString() == truckTractor.Semitrailer)
                        semitrailer = (Semitrailer)v1;
                if (semitrailer.MassOfGoods - mass >= 0 && semitrailer.TypeOfGoods == typeOfGoods)
                    semitrailer.MassOfGoods = semitrailer.MassOfGoods - mass;
                foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                {
                    if (v1 is Semitrailer && v1.ToString() == truckTractor.Semitrailer)
                        transports.Add((Transport)semitrailer);
                    else
                        transports.Add(v1);
                }
                SaxParser.AddInXml(transports, pathForSaveChange);
                return semitrailer.MassOfGoods;
            }
            /// <summary>
            /// method for unloading goods
            /// </summary>
            /// <param name="truckTractor">truck tractor</param>
            /// <param name="typeOfGoods">type of goods</param>
            /// <param name="pathForSaveChange">path for save change</param>
            /// <returns>new mass</returns>
            public double OpportunitiesOfLogisticiansMinusAllGood(TruckTractor truckTractor, string typeOfGoods, string pathForSaveChange)
            {
                List<Transport> transports = new List<Transport>();

                Semitrailer semitrailer = new Semitrailer();
                foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                    if (v1 is Semitrailer && v1.ToString() == truckTractor.Semitrailer)
                        semitrailer = (Semitrailer)v1;
                if (semitrailer.MassOfGoods > 0 && semitrailer.TypeOfGoods == typeOfGoods)
                    semitrailer.MassOfGoods = 0;
                foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                {
                    if (v1 is Semitrailer && v1.ToString() == truckTractor.Semitrailer)
                        transports.Add((Transport)semitrailer);
                    else
                        transports.Add(v1);
                }
                SaxParser.AddInXml(transports, pathForSaveChange);

                return semitrailer.MassOfGoods;
            }
            /// <summary>
            /// Method for replace semitrailer
            /// </summary>
            /// <param name="truckTractor">truck tractor</param>
            /// <param name="semitrailer">semitrailer</param>
            /// <param name="pathForSaveChange">path for save change</param>
            /// <returns>truck tractor</returns>
            public TruckTractor ReplaceSemitrailer(TruckTractor truckTractor, Semitrailer semitrailer, string pathForSaveChange)
            {
                List<Transport> transports = new List<Transport>();
                foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                    if (v1 is TruckTractor && v1 == truckTractor)
                        truckTractor = (TruckTractor)v1;
                
          
                truckTractor.Semitrailer = semitrailer.ToString();
                foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                {
                    if (v1 is TruckTractor && v1.Name == truckTractor.Name)
                        transports.Add((Transport)truckTractor);
                    else
                        transports.Add(v1);
                }
                SaxParser.AddInXml(transports, pathForSaveChange);

                return truckTractor;
            }
            /// <summary>
            /// Method for delete semitrailer
            /// </summary>
            /// <param name="truckTractor">truck tractor</param>
            /// <param name="pathForSaveChange">path for save change</param>
            /// <returns>truck tractor</returns>
            public TruckTractor DeleteSemitrailer(TruckTractor truckTractor, string pathForSaveChange)
            {
                List<Transport> transports = new List<Transport>();

                foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml")) 
                    if (v1 is TruckTractor && v1 == truckTractor)
                        truckTractor = (TruckTractor)v1;
                truckTractor.Semitrailer = "";
                foreach (var v1 in SaxParser.SaxParsing(@"../../CarPark.xml"))
                {
                    if (v1 is TruckTractor && v1.Name == truckTractor.Name)
                        transports.Add((Transport)truckTractor);
                    else
                        transports.Add(v1);
                }
                SaxParser.AddInXml(transports, pathForSaveChange);
                return truckTractor;
            }
        }
    }
}
