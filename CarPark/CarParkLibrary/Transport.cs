using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkLibrary
{
    
    public abstract class Transport
    {
        public string Name { get; set; }
        public double MaxMass { get; set; }

        public Transport()
        { }
        public Transport(string name, double maxMass)
        {
            Name = name;
            MaxMass = maxMass;
        }

        abstract public Transport Create();
        /// <summary>
        /// Override method ToString()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString() => Name + "(" + MaxMass + ")";

        /// <summary>
        /// Method overriding GetHashCode()
        /// </summary>
        /// <returns>Hash-code</returns>
        public override int GetHashCode()
        {
            return Name.Length;
        }

        /// <summary>
        /// Method overriding Equals()
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Transport transport = (Transport)obj;
            if (Name != transport.Name || MaxMass != MaxMass)
                return false;
            return true;
        }
    }
}
