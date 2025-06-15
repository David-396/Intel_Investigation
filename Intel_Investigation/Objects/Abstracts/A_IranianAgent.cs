using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;

namespace Intel_Investigation.Objects.Abstracts
{
    abstract class A_IranianAgent
    {
        protected AgentRank AgentRank;
        protected int SensorsNumber;
        protected AgentRank[] AgentRanksList;


        public A_IranianAgent(AgentRank agentRank, AgentRank[] agentRanksList, int sensorsNumber)
        {
            this.AgentRank = agentRank;
            this.AgentRanksList = agentRanksList;
            this.SensorsNumber = sensorsNumber;
        }
    }
}
