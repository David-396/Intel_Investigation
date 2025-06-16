using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;
using Intel_Investigation.Objects.Abstracts;


namespace Intel_Investigation.Objects
{
    internal class BasicSensor : A_Sensor
    {
        public BasicSensor() : base(SensorType.Basic) { }


        public override void Active()
        {
            Console.WriteLine($"{this.type} sensor is active");
        }
    }
}
