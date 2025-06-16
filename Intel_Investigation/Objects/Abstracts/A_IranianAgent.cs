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
        protected string[] Sensors;
        protected int SensorsNumber;
        protected bool isExposed;


        public A_IranianAgent(AgentRank agentRank, string[] Sensors)
        {
            this.AgentRank = agentRank;
            this.Sensors = Sensors;
            this.SensorsNumber = Sensors.Length;
            this.isExposed = false;
        }

        public void Expose()
        {
            Console.WriteLine($"\n{this.AgentRank} Iranian agent has exposed\n");
            this.isExposed = true;
        }
    }
}
