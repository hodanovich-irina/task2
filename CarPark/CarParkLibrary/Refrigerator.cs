using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkLibrary
{
    /// <summary>
    /// сhild class from Semitrailer
    /// </summary>
    public class Refrigerator : Semitrailer
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Refrigerator()
        {
        }
        /// <summary>
        /// Constructor with params 
        /// </summary>
        /// <param name="name">brand of transport</param>
        /// <param name="maxMass">Lifting capacity</param>
        /// <param name="typeOfGoods">type of goods</param>
        /// <param name="storageConditions">storage conditions</param>
        /// <param name="mass">busy weight</param>
        /// <param name="massOfGoods">mass of goods</param>
        public Refrigerator(string name, double maxMass, string typeOfGoods, string storageConditions, double mass, double massOfGoods) 
            : base(name, maxMass, typeOfGoods, storageConditions, mass, massOfGoods)
        {
        }
        /// <summary>
        /// method for creating an instance of the class
        /// </summary>
        /// <returns>instance of the class</returns>
        public override Transport Create()
        {
            return new Refrigerator();
        }

        /// <summary>
        /// Method overriding Equals()
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            return obj is Refrigerator refrigerator &&
                   base.Equals(obj) &&
                   Name == refrigerator.Name &&
                   MaxMass == refrigerator.MaxMass &&
                   TypeOfGoods == refrigerator.TypeOfGoods &&
                   StorageConditions == refrigerator.StorageConditions &&
                   Mass == refrigerator.Mass &&
                   MassOfGoods == refrigerator.MassOfGoods;
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

        /// <summary>
        /// Override method ToString()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
