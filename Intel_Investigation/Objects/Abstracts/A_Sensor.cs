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
        protected SensorType type;

        public A_Sensor(SensorType type)
        {
            this.type = type;
        }


        public abstract void Active();

    }
}
