﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Objects.Abstracts;
using Intel_Investigation.Enums;

namespace Intel_Investigation.Objects
{
    internal class Pulse : Sensor
    {
        public int timeActivated;

        public Pulse(IranianAgent agent) : base(SensorType.pulse, agent)
        {
            this.timeActivated = 0;
        }

        public override bool Active()
        {
            if(this.timeActivated < 3)
            {
                this.timeActivated ++;
                if(this.timeActivated == 3)
                {
                    this.agentHolder.copiedSensors[Array.IndexOf(this.agentHolder.OriginalSensors, this.type.ToString())] = null;
                    this.agentHolder.sensorExploded++;
                    this.agentHolder.guessedRight--;
                    this.agentHolder.SensorsNumber--;
                    Console.WriteLine("\n - PULSE SENSOR HAS BLOWED UP - \n");
                }
                return base.Active();

            }
            else
            {
                Console.WriteLine("\nthis sensor blowed up\n");
                return false;
            }
        }
    }
}
