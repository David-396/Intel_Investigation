using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;
using Intel_Investigation.Objects.Abstracts;

namespace Intel_Investigation.Objects
{
    internal class Thermal : A_Sensor
    {
        public Thermal(A_IranianAgent agent) : base(SensorType.thermal, agent) { }


        public override bool Active()
        {
            
            base.Active();
            Random rnd = new Random();
            int rnd_index = rnd.Next(this.agentHolder.SensorsNumber);
            Console.WriteLine($"you revealed  one correct sensor - {this.agentHolder.OriginalSensors[rnd_index]}");
            return true;
        }

    }
}
