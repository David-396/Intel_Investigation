using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Objects.Abstracts;
using Intel_Investigation.Enums;

namespace Intel_Investigation.Objects
{
    internal class SeniorCommander : SquadLeader
    {
        public SeniorCommander(string[] sensors) : base(sensors)
        {
            this.AgentRank = AgentRank.SeniorCommander;
        }

        public override void CounterAttack()
        {
            this.PrintAttack();
            this.RaiseTurn();

            if (this.turns % 3 == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    int index = RandInt(this.copiedSensors.Length);
                    this.copiedSensors[index] = null;
                }
            }

        }
    }
}
