using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Objects.Abstracts;
using Intel_Investigation.Enums;

namespace Intel_Investigation.Objects
{
    internal class PulseSensor : A_Sensor
    {
        public int timeActivated = 0;

        public PulseSensor() : base(SensorType.PulseSensor) { }

        public override void Active()
        {
            if(this.timeActivated < 3)
            {
                this.timeActivated += 1;

            }
            else
            {

            }
        }
    }
}
