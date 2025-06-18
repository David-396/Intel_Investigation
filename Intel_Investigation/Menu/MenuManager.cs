using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Objects.Abstracts;
using Intel_Investigation.Objects;
using Intel_Investigation.Enums;
using System.Collections.Generic;

namespace Intel_Investigation.Menu
{
    internal class MenuManager
    {
        // the current agent
        public IranianAgent currentIranianAgent;

        // all the instances of the sensors to activate them 
        public Sensor[] sensorsInstances;

        // all the sensors in string - to validate the sensor input
        public string[] currentIrnSensors;

        // the number of the agent sensors - to show him the right answers...
        public int sensorsNumber;

        // the number of turns he needed to win
        public int totalTurns;


        public MenuManager(AgentRank rank)
        {
            this.currentIranianAgent = CreateAgent(rank);
            this.currentIrnSensors = Statics.CopyArr(this.currentIranianAgent.OriginalSensors);
            this.sensorsNumber = currentIranianAgent.SensorsNumber;
            this.sensorsInstances = SensorsToInstance();
            this.totalTurns = 0;
        }


        public Sensor CreateSensor(string sensorName, IranianAgent agent)
        {
            switch(sensorName)
            {
                case "audio":
                    return new Audio(agent);

                case "thermal":
                    return new Thermal(agent);

                case "pulse":
                    return new Pulse(agent);

                case "motion":
                    return new Motion(agent);

                case "magnetic":
                    return new Magnetic(agent);

                case "signal":
                    return new Signal(agent);

                case "light":
                    return new Light(agent);

                default:
                    return null;
            }
        }

        // create an Iranian agent instance
        public IranianAgent CreateAgent(AgentRank rank)   
        {
            switch (rank)
            {
                case AgentRank.FootSoldier:
                    return new FootSoldier(Statics.RandomSensorArr((int)rank, Statics.allSensors));

                case AgentRank.SquadLeader:
                    return new SquadLeader(Statics.RandomSensorArr((int)rank, Statics.allSensors));

                case AgentRank.SeniorCommander:
                    return new SeniorCommander(Statics.RandomSensorArr((int)rank, Statics.allSensors));

                case AgentRank.OrganizationLeader:
                    return new OrganizationLeader(Statics.RandomSensorArr((int)rank, Statics.allSensors));

                default:
                    return null;
            }
        }                                                                                                            
        



        // main function
        public float Run()
        {
            UI.PrintMenu();

            do
            {
                // get the sensor from user - it must to be one of the known sensors from the sensors names in Statics class
                UI.PrintEnterSensor(Statics.allSensors);
                string sensor = Statics.GetSensor(Statics.allSensors);

                // if the sensor in the sensors names list
                if (currentIrnSensors.Contains(sensor))
                {
                    // look up for an appropriate sensor instance to activate him 
                    Sensor activate_sensor = FindSensorInstance(sensor, this.sensorsInstances);

                    if(activate_sensor != null)
                    {
                        activate_sensor.Active();

                    }

                }

                // check if the agent can make a counter attack - agent.CounterAttack()
                if (this.currentIranianAgent.cancelCounterAttackByTurns == 0)
                {
                    this.currentIranianAgent.CounterAttack();
                }
                // if there more turns to not allowed to make the counter attack (like magnetic sensors) - sub the turns in 1
                else
                {
                    this.currentIranianAgent.cancelCounterAttackByTurns--;
                }

                /* if needed to reset all the sensors lists (like organization leader after 10 turns):
                update the lists that saved in the menu manager to the agent list */
                if (this.currentIranianAgent.ifReset)
                {
                    this.UpdateSensorsLists();
                    this.currentIranianAgent.ifReset = false;
                }


                // print how he answered right
                UI.PrintHowMuchRightAnswers(currentIranianAgent.guessedRight, currentIranianAgent.SensorsNumber);
                this.totalTurns++;

            } while (currentIranianAgent.guessedRight != currentIranianAgent.SensorsNumber);

            //Console.Clear();
            UI.PrintFinalRes(currentIranianAgent.guessedRight, (int)currentIranianAgent.AgentRank);
            currentIranianAgent.Expose();
            UI.PrintWonAndExit();
            return (currentIranianAgent.guessedRight / (int)currentIranianAgent.AgentRank) * 100;
        }
            


        // take a list of string sensors and returns a new list of their instances
        public Sensor[] SensorsToInstance()
        {
            Sensor[] sensorsToInstances = new Sensor[this.sensorsNumber];
            int i = 0;
            foreach(string sensor in this.currentIranianAgent.OriginalSensors)
            {
                sensorsToInstances[i] = CreateSensor(sensor.ToLower(), this.currentIranianAgent);
                i++;
            }
            return sensorsToInstances;
        }


        // returns an instance of sensor to activate
        static Sensor FindSensorInstance(string sensorName, Sensor[] sensors)
        {
            Sensor return_sensor = null;
            foreach(Sensor sensor in sensors)
            {
                if(sensor.type == Enum.Parse<SensorType>(sensorName))
                {
                    if (!sensor.isActivated)
                    {
                        return sensor;
                    }
                    return_sensor = sensor;
                }
            }
            return return_sensor;
        }



        // reset function for organization leader
        void UpdateSensorsLists()
        {
            this.currentIrnSensors = Statics.CopyArr(this.currentIranianAgent.OriginalSensors);
            this.sensorsInstances = SensorsToInstance();
        }
    }
}
