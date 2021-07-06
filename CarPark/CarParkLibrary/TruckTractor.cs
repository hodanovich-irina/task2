using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkLibrary
{
    /// <summary>
    /// Child class from Transport
    /// </summary>
    public class TruckTractor : Transport
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public TruckTractor() { }
        /// <summary>
        /// Property for semitrailer
        /// </summary>
        public string Semitrailer { get; set; }
        /// <summary>
        /// Property for fuel consumption
        /// </summary>
        public double FuelConsumption {get; set;}

        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="maxMass">lifting capacity</param>
        /// <param name="fuelConsumption">fuel consumption</param>
        /// <param name="semitrailer">semitrailer</param>
        public TruckTractor(string name, double maxMass , double fuelConsumption,string semitrailer) : base(name, maxMass)
        {
            FuelConsumption = fuelConsumption;
            Semitrailer = semitrailer;
        }

        /// <summary>
        /// method for creating an instance of the class
        /// </summary>
        /// <returns>instance of the class</returns>
        public override Transport Create()
        {
            return new TruckTractor();
        }


        /// <summary>
        /// Override method ToString()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Method overriding Equals()
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            return obj is TruckTractor tractor &&
                   base.Equals(obj) &&
                   Name == tractor.Name &&
                   MaxMass == tractor.MaxMass &&
                   Semitrailer == tractor.Semitrailer &&
                   FuelConsumption == tractor.FuelConsumption;
        }

        /// <summary>
        /// Method overriding GetHashCode()
        /// </summary>
        /// <returns>Hash-code</returns>
        public override int GetHashCode()
        {
            int hashCode = -365807353;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + MaxMass.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Semitrailer);
            hashCode = hashCode * -1521134295 + FuelConsumption.GetHashCode();
            return hashCode;
        }
    }
}
