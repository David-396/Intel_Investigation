using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Objects.Abstracts;
using Intel_Investigation.Enums;

namespace Intel_Investigation.Objects
{
    internal class Magnetic : A_Sensor
    {

        public Magnetic(A_IranianAgent agent) : base(SensorType.magnetic, agent){}

        public override bool Active()
        {
            if (this.isActivated)
            {
                this.PrintSensorUsed();
                return false;
            }
            base.Active();
            this.agentHolder.cancelCounterAttackByTurns = 2;
            Console.WriteLine("- the terrorist cannot make a counter attack for 2 turns - ");
            return true;
        }
    }
}
