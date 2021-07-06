using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkLibrary
{
    /// <summary>
    /// Parent class for description the transport
    /// </summary>
    public abstract class Transport
    {
        /// <summary>
        /// Brand of transport
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Lifting capacity
        /// </summary>
        public double MaxMass { get; set; }
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Transport()
        { }
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="maxMass">lifting capacity</param>
        public Transport(string name, double maxMass)
        {
            Name = name;
            MaxMass = maxMass;
        }

        /// <summary>
        /// method for creating an instance of the class
        /// </summary>
        /// <returns>instance of the class</returns>
        abstract public Transport Create();

        /// <summary>
        /// Override method ToString()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString() => Name + "(" + MaxMass + ")";


        /// <summary>
        /// Method overriding Equals()
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            return obj is Transport transport &&
                   Name == transport.Name &&
                   MaxMass == transport.MaxMass;
        }

        /// <summary>
        /// Method overriding GetHashCode()
        /// </summary>
        /// <returns>Hash-code</returns>
        public override int GetHashCode()
        {
            int hashCode = -1131729933;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + MaxMass.GetHashCode();
            return hashCode;
        }
    }
}
