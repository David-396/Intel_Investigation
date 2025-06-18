using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Objects.Abstracts;
using Intel_Investigation.Enums;

namespace Intel_Investigation.Objects
{
    internal class Signal : Sensor
    {

        public Signal(IranianAgent agent) : base(SensorType.signal, agent){}



        public override bool Active()
        {
            if (!this.isActivated)
            {
                base.Active();
                this.RevealInformation(1, this.agentHolder.info);
                return true;
            }

            this.PrintSensorUsed();
            return false;
        }


        
    }
}
