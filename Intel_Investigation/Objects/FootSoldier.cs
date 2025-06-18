using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;
using Intel_Investigation.Objects.Abstracts;


namespace Intel_Investigation.Objects
{
    internal class FootSoldier : IranianAgent
    {
        public FootSoldier(string[] sensors) : base( sensors)
        {
            this.AgentRank = AgentRank.FootSoldier;
        }
    }

}
