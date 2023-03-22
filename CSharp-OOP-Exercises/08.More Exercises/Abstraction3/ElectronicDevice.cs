using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction3
{
    public class ElectronicDevice
    {
        private List<IDeviceOption> devices;
        public ElectronicDevice()
        {
            devices = new List<IDeviceOption>();
        }
        public IEnumerable<IDeviceOption> Items => this.devices;
        public void AddDevice(IDeviceOption deviceOption) 
        {
            devices.Add(deviceOption);
        }
    }
}
