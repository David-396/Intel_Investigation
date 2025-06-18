using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;
using Intel_Investigation.Objects.Abstracts;
using Intel_Investigation.Menu;

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
            this.RaiseTurn();

            if (this.turns % 3 == 0)
            {
                this.PrintAttack();
                int index = Statics.RandInt(this.copiedSensors.Length);
                this.copiedSensors[index] = null;
            }

        }
    }
}
