﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;
using Intel_Investigation.Menu;
using Intel_Investigation.Objects.Abstracts;

namespace Intel_Investigation.Objects
{
    internal class Thermal : Sensor
    {
        public Thermal(IranianAgent agent) : base(SensorType.thermal, agent) { }


        public override bool Active()
        {
            
            base.Active();
            int rnd_index = Statics.RandInt(this.agentHolder.SensorsNumber);
            string sensor = this.agentHolder.copiedSensors[rnd_index];
            Console.WriteLine($"you revealed  one correct sensor - {sensor}");
            return true;
        }

    }
}
