using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;

namespace Intel_Investigation.Objects.Abstracts
{
    abstract class IranianAgent
    {
        public int turns;
        public AgentRank AgentRank { get; set; }
        public string[] OriginalSensors { get; set; }
        public string[] copiedSensors { get; set; }
        public int guessedRight;
        public int SensorsNumber { get; set; }
        public int sensorExploded { get; set; }
        public bool ifReset;
        public int cancelCounterAttackByTurns = 0;
        public string[] info = { "name : Haminai", "age: 2376" , "address : underground"};
        protected bool isExposed;


        public IranianAgent(string[] Sensors)
        {
            this.OriginalSensors = Sensors;
            this.copiedSensors = Sensors;
            this.SensorsNumber = Sensors.Length;
            this.isExposed = false;
            this.sensorExploded = 0;
            this.guessedRight = 0;
            this.turns = 0;
        }


        public virtual void CounterAttack()
        {
            this.RaiseTurn();
        }

        public void PrintAttack()
        {
            Console.WriteLine($"{this.AgentRank} is attacking back ");
        }
        public void RaiseTurn()
        {
            this.turns++;
        }

        public void Expose()
        {
            Console.WriteLine($"\n{this.AgentRank} Iranian agent has exposed\n");
            this.isExposed = true;
        }

        public void ResetTurns()
        {
            this.turns = 0;
        }

    }
}
