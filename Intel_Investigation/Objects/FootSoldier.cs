using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;
using Intel_Investigation.Objects.Abstracts;


namespace Intel_Investigation.Objects
{
    internal class FootSoldier : A_IranianAgent
    {
        public FootSoldier(SensorType[] sensors) : base(AgentRank.FootSoldier, sensors) { }
    }
}
