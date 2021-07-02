using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkLibrary
{
    public interface ISemitrailer
    {
        string TypeOfGoods { get; set; }
        string StorageConditions { get; set; }
        double Mass { get; set; }
        double MassOfGoods { get; set; }
        double AvailableVolume();
    }
}
