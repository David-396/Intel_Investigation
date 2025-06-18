using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;
using Intel_Investigation.Objects.Interfaces;
using Intel_Investigation.Menu;

namespace Intel_Investigation.Objects.Abstracts
{
    abstract class A_Sensor : IActive
    {
        public SensorType type {  get; }
        protected A_IranianAgent agentHolder;
        public bool isActivated = false;

        public A_Sensor(SensorType type, A_IranianAgent agentHolder)
        {
            this.type = type;
            this.agentHolder = agentHolder;
        }


        public virtual bool Active()
        {
            this.PrintSensorActivated();
            if (!this.isActivated)
            {
                this.RaiseAnswer();
                this.UpdateIsActivated();
            }
            return true;
        }


        public void RaiseAnswer()
        {
            this.agentHolder.guessedRight++;
        }
        public void UpdateIsActivated()
        {
            this.isActivated = true;
        }
        public void PrintSensorActivated()
        {
            Console.WriteLine($"{this.type} sensor is active");
        }
        public void PrintSensorUsed()
        {
            Console.WriteLine("you can't use this sensor again");
        }

        public void RevealInformation(int reveals, string[] info)
        {
            Console.WriteLine($"you revealed {reveals} information: ");
            for (int i = 0; i < reveals; i++) 
            {
                int index = Statics.RandInt(info.Length);
                Console.WriteLine(info[index]);
            }
        }
    }
}
