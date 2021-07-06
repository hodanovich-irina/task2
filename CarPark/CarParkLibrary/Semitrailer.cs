using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkLibrary
{
    /// <summary>
    /// Child class from Transport, ISemitrailer
    /// </summary>
    public class Semitrailer : Transport, ISemitrailer
    {
        /// <summary>
        /// property for type of goods
        /// </summary>
        public string TypeOfGoods { get; set; }
        /// <summary>
        /// property for storage conditions
        /// </summary>
        public string StorageConditions { get; set; }
        /// <summary>
        /// property for busy weight
        /// </summary>
        public double Mass { get; set; }
        /// <summary>
        /// property for mass of goods
        /// </summary>
        public double MassOfGoods { get; set; }

        /// <summary>
        /// Constructor with params 
        /// </summary>
        /// <param name="name">brand of transport</param>
        /// <param name="maxMass">Lifting capacity</param>
        /// <param name="typeOfGoods">type of goods</param>
        /// <param name="storageConditions">storage conditions</param>
        /// <param name="mass">busy weight</param>
        /// <param name="massOfGoods">mass of goods</param>
        public Semitrailer(string name, double maxMass, string typeOfGoods, string storageConditions, double mass, double massOfGoods) : base(name, maxMass)
        {
            TypeOfGoods = typeOfGoods;
            StorageConditions = storageConditions;
            Mass = mass;
            MassOfGoods = massOfGoods;
        }
        
        /// <summary>
        /// empty constructor
        /// </summary>
        public Semitrailer()
        {
        }
        /// <summary>
        /// method for calculating free volume
        /// </summary>
        /// <returns>free volume</returns>
        public double AvailableVolume()
        { 
            return MaxMass - Mass -  MassOfGoods; 
        }
        /// <summary>
        /// method for creating an instance of the class
        /// </summary>
        /// <returns>instance of the class</returns>
        public override Transport Create()
        {
            return new Semitrailer();
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
            return obj is Semitrailer semitrailer &&
                   base.Equals(obj) &&
                   Name == semitrailer.Name &&
                   MaxMass == semitrailer.MaxMass &&
                   TypeOfGoods == semitrailer.TypeOfGoods &&
                   StorageConditions == semitrailer.StorageConditions &&
                   Mass == semitrailer.Mass &&
                   MassOfGoods == semitrailer.MassOfGoods;
        }
        /// <summary>
        /// Method overriding GetHashCode()
        /// </summary>
        /// <returns>Hash-code</returns>
        public override int GetHashCode()
        {
            int hashCode = -1502693678;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + MaxMass.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TypeOfGoods);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StorageConditions);
            hashCode = hashCode * -1521134295 + Mass.GetHashCode();
            hashCode = hashCode * -1521134295 + MassOfGoods.GetHashCode();
            return hashCode;
        }
    }
}
