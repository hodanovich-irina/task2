using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkLibrary
{
    /// <summary>
    /// Interface for all common semitrailer properties
    /// </summary>
    public interface ISemitrailer
    {
        /// <summary>
        /// property for type of goods
        /// </summary>
        string TypeOfGoods { get; set; }

        /// <summary>
        /// property for storage conditions
        /// </summary>
        string StorageConditions { get; set; }

        /// <summary>
        /// property for busy weight in semitrailer
        /// </summary>
        double Mass { get; set; }

        /// <summary>
        /// property for mass of goods in semitrailer
        /// </summary>
        double MassOfGoods { get; set; }

        /// <summary>
        /// method for calculating free volume
        /// </summary>
        /// <returns>free volume</returns>
        double AvailableVolume();
    }
}
