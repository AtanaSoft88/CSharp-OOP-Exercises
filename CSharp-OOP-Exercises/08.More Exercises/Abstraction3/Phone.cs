using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction3
{
    public class Phone : ITalkable, IDeviceOption
    {
        public Phone(string model, int maxCap, int currPerc)
        {
            this.Model = model;
            this.MaxCapacity = maxCap;
            this.CurrentPercentage = currPerc;
        }
        public string Model { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentPercentage { get; set; }

        private bool CanTalk(int currentBatteryPercentage) 
        {
            return currentBatteryPercentage > 0;
        }

        public string DisplayBatteryPercentage()
        {
            return CurrentPercentage.ToString();
        }
        public string Talk()
        {
            if (this.CanTalk(this.CurrentPercentage))
            {
                if (this.CurrentPercentage - 20 <= 0)
                {
                    this.CurrentPercentage = 0;
                    return $"Can't talk anymore battery level is at : {this.CurrentPercentage}";
                }
                else
                {
                    this.CurrentPercentage -= 20;
                }
                return $"Talk more! battery level is at : {this.CurrentPercentage}";
            }
            return $"Can't talk anymore battery level is at : {this.CurrentPercentage}";


        }

        public string ChargeBattery()
        {
            int previousValue = CurrentPercentage;
            if (CurrentPercentage < MaxCapacity)
            {
                CurrentPercentage = MaxCapacity;

            }
            return $"{Model} was recharged from {previousValue}% to {CurrentPercentage}%.\r\n--Total charging: {CurrentPercentage - previousValue}";
        }

        public string WatchMovie()
        {
            if (this.CurrentPercentage - 15 <= 0)
            {
                this.CurrentPercentage = 0;
                return "No Energy to perform watching movies! Please recharge the device!";
            }
            else
            {
                this.CurrentPercentage -= 15;
                return $"Device lost 15 from his battery by watching movies...Current battery: {CurrentPercentage}";
            }
        }
    }
}
