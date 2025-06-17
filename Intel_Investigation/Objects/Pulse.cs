using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Objects.Abstracts;
using Intel_Investigation.Enums;

namespace Intel_Investigation.Objects
{
    internal class Pulse : A_Sensor
    {
        public int timeActivated;

        public Pulse(A_IranianAgent agent) : base(SensorType.pulse, agent)
        {
            this.timeActivated = 0;
        }

        public override bool Active()
        {
            if(this.timeActivated < 3)
            {
                this.timeActivated += 1;
                if(this.timeActivated == 3)
                {
                    this.agentHolder.copiedSensors[Array.IndexOf(this.agentHolder.OriginalSensors, this.type.ToString())] = null;
                    this.agentHolder.sensorExploded++;
                }
                return base.Active();

            }
            else
            {
                Console.WriteLine("\n🔥 the sensor blow up 🔥\n");
                return false;
            }
        }
    }
}
