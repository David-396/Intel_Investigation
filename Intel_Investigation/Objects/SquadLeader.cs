using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;
using Intel_Investigation.Objects.Abstracts;

namespace Intel_Investigation.Objects
{
    internal class SquadLeader : A_IranianAgent
    {
        public SquadLeader(string[] sensors) : base(AgentRank.SquadLeader, sensors) { }
    }
}
