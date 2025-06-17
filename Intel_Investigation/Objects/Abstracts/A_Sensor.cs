using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;
using Intel_Investigation.Objects.Interfaces;

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
            Console.WriteLine($"{this.type} sensor is active");
            if (!this.isActivated)
            {
                this.agentHolder.guessedRight++;
                this.isActivated = true;
            }
            return true;
        }
    }
}
