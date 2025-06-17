using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;
using Intel_Investigation.Objects.Abstracts;

namespace Intel_Investigation.Objects
{
    internal class SquadLeader : FootSoldier
    {
        public SquadLeader(string[] sensors) : base( sensors)
        {
            this.AgentRank = AgentRank.SquadLeader;
        }

        public override void CounterAttack()
        {
            base.CounterAttack();

            if(this.turns % 3 == 0)
            {
                int index = RandInt(this.copiedSensors.Length);
                this.copiedSensors[index] = null;
            }

        }
    }
}
