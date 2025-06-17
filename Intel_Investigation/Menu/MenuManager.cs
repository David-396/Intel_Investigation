using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Objects.Abstracts;
using Intel_Investigation.Objects;
using Intel_Investigation.Enums;
using System.Collections.Generic;
using Intel_Investigation.Validate;

namespace Intel_Investigation.Menu
{
    internal class MenuManager
    {

        public A_IranianAgent currentIranianAgent;
        public A_Sensor[] sensorsInstances;
        public string[] currentIrnSensors;
        public int sensorsNumber;


        public MenuManager(AgentRank rank)
        {
            this.currentIranianAgent = CreateAgent(rank);
            this.currentIrnSensors = Statics.CopyArr(this.currentIranianAgent.OriginalSensors);
            this.sensorsNumber = currentIranianAgent.SensorsNumber;
            this.sensorsInstances = SensorsToInstance();
        }


        public A_Sensor CreateSensor(string sensorName, A_IranianAgent agent)
        {
            switch(sensorName)
            {
                case "audio":
                    return new Audio(agent);

                case "thermal":
                    return new Thermal(agent);

                case "pulse":
                    return new Pulse(agent);

                default:
                    return null;
            }
        }

        // create an Iranian agent instance
        public A_IranianAgent CreateAgent(AgentRank rank)   
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
        public void Run()
        {
            UI.PrintMenu();

            do
            {
                UI.PrintEnterSensor(this.currentIrnSensors);
                string sensor = Statics.GetSensor(Statics.allSensors);

                if (currentIrnSensors.Contains(sensor))
                {
                    A_Sensor activate_sensor = FindSensorInstance(sensor, this.sensorsInstances);

                    if(activate_sensor != null)
                    {
                        activate_sensor.Active();

                    }

                }
                this.currentIranianAgent.CounterAttack();

                if (this.currentIranianAgent.ifReset)
                {
                    this.UpdateSensorsLists();
                    this.currentIranianAgent.ifReset = false;
                }

                UI.PrintHowMuchRightAnswers(currentIranianAgent.guessedRight, sensorsNumber);

            } while (currentIranianAgent.guessedRight != currentIranianAgent.SensorsNumber - currentIranianAgent.sensorExploded);

            UI.PrintFinalRes(currentIranianAgent.guessedRight, currentIranianAgent.SensorsNumber);
            currentIranianAgent.Expose();
            UI.PrintWonAndExit();
        }
            


        // take a list of string sensors and returns a new list of their instances
        public A_Sensor[] SensorsToInstance()
        {
            A_Sensor[] sensorsToInstances = new A_Sensor[this.sensorsNumber];
            int i = 0;
            foreach(string sensor in this.currentIranianAgent.OriginalSensors)
            {
                sensorsToInstances[i] = CreateSensor(sensor.ToLower(), this.currentIranianAgent);
                i++;
            }
            return sensorsToInstances;
        }


        // returns an instance of sensor to activate
        static A_Sensor FindSensorInstance(string sensorName, A_Sensor[] sensors)
        {
            A_Sensor return_sensor = null;
            foreach(A_Sensor sensor in sensors)
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
