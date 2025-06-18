using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Objects.Abstracts;
using Intel_Investigation.Enums;
using Intel_Investigation.Menu;

namespace Intel_Investigation.Objects
{
    internal class OrganizationLeader : SeniorCommander
    {
        public OrganizationLeader(string[] sensors) : base(sensors)
        {
            this.AgentRank = AgentRank.OrganizationLeader;
        }

        public override void CounterAttack()
        {
            this.RaiseTurn();
            
            if(this.turns % 3 == 0 || this.turns % 10 == 0)
            {
                this.PrintAttack();

                if (this.turns % 3 == 0)
                {
                    this.copiedSensors[0] = null;
                }

                if(this.turns % 10 == 0)
                {
                    this.ifReset = true;
                    this.ResetSensorsLists();
                    this.ResetGeussedRight();
                    this.ResetSensorExploded();
                    this.ResetLastSensor();

                }

            }
        }

        // resets functions
        public void ResetSensorsLists()
        {
            this.OriginalSensors = Statics.RandomSensorArr((int)this.AgentRank, Statics.allSensors);
            this.copiedSensors = Statics.CopyArr(this.OriginalSensors);
        }
        public void ResetGeussedRight()
        {
            this.guessedRight = 0;
        }
        public void ResetSensorExploded()
        {
            this.sensorExploded = 0;
        }
        public void ResetLastSensor()
        {
            this.lastSensor = null;
        }
    }
}
