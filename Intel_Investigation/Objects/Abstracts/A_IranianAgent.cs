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
        public int turns;
        public AgentRank AgentRank { get; set; }
        public string[] OriginalSensors { get; set; }
        public string[] copiedSensors { get; set; }
        public int guessedRight;
        public int SensorsNumber {  get; }
        public int sensorExploded { get; set; }
        protected bool isExposed;
        public A_Sensor lastSensor;
        public bool ifReset;
        public int cancelCounterAttackByTurns = 0;


        public A_IranianAgent(string[] Sensors)
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
            this.PrintAttack();
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

        public static int RandInt(int limit)
        {
            Random rnd = new Random();
            return rnd.Next(limit);
        }

    }
}
