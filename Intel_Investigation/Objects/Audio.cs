using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;
using Intel_Investigation.Objects.Abstracts;


namespace Intel_Investigation.Objects
{
    internal class Audio : A_Sensor
    {
        public Audio(A_IranianAgent agent) : base(SensorType.audio, agent) { }


        public override bool Active()
        {
            return base.Active();
        }
    }
}
