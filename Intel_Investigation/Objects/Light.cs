using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Objects.Abstracts;
using Intel_Investigation.Enums;

namespace Intel_Investigation.Objects
{
    internal class Light : A_Sensor
    {

        public Light(A_IranianAgent agent) : base(SensorType.light, agent) { }


        public override bool Active()
        {
            if (!this.isActivated)
            {
                base.Active();
                this.RevealInformation(2, this.agentHolder.info);
                return true;
            }

            this.PrintSensorUsed();
            return false;
        }
    }
}
