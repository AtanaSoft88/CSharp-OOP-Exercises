using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction3
{
    public interface IDeviceOption
    {
        string ChargeBattery();
        string WatchMovie();
        string DisplayBatteryPercentage();
    }
}
