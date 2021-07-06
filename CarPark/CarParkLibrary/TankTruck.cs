using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkLibrary
{
    /// <summary>
    /// View of fuel for tank truck
    /// </summary>
    public enum ViewFuel
    {
        /// <summary>
        /// AI98
        /// </summary>
        AI98 = 1,
        /// <summary>
        /// AI95
        /// </summary>
        AI95,
        /// <summary>
        /// AI92
        /// </summary>
        AI92,
        /// <summary>
        /// AI80
        /// </summary>
        AI80,
        /// <summary>
        /// Disel
        /// </summary>
        Diesel,
        /// <summary>
        /// Gas
        /// </summary>
        Gas
    }
    /// <summary>
    /// сhild class from Semitrailer
    /// </summary>
    public class TankTruck : Semitrailer
    {            
        /// <summary>
        /// property for view fuel
        /// </summary>
        public ViewFuel ViewFuel { get; set; }

        /// <summary>
        /// Constructor with params 
        /// </summary>
        /// <param name="name">brand of transport</param>
        /// <param name="maxMass">Lifting capacity</param>
        /// <param name="typeOfGoods">type of goods</param>
        /// <param name="storageConditions">storage conditions</param>
        /// <param name="mass">busy weight</param>
        /// <param name="massOfGoods">mass of goods</param>
        /// <param name="viewFuel">view of fuel</param>
        public TankTruck(string name, double maxMass, string typeOfGoods, string storageConditions, double mass, double massOfGoods, ViewFuel viewFuel) : base(name, maxMass, typeOfGoods, storageConditions, massOfGoods, mass)
        {
            ViewFuel = viewFuel;
        }
        /// <summary>
        /// empty constructor
        /// </summary>
        public TankTruck()
        {
        }
        /// <summary>
        /// method for creating an instance of the class
        /// </summary>
        /// <returns>instance of the class</returns>
        public override Transport Create()
        {
            return new TankTruck();
        }

        /// <summary>
        /// Method overriding Equals()
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            return obj is TankTruck truck &&
                   base.Equals(obj) &&
                   ViewFuel == truck.ViewFuel;
        }
        /// <summary>
        /// Method overriding GetHashCode()
        /// </summary>
        /// <returns>Hash-code</returns>
        public override int GetHashCode()
        {
            int hashCode = -2084488606;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + ViewFuel.GetHashCode();
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
