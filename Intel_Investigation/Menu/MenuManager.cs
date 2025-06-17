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
        // fields to create a random rank/sensorsArr
        static AgentRank[] allRanks = { AgentRank.FootSoldier, AgentRank.SquadLeader , AgentRank.SeniorCommander, AgentRank.OrganizationLeader};

        static string[] allSensors = { "audio", "thermal", "pulse" };


        public A_IranianAgent currentIranianAgent;
        public A_Sensor[] sensorsInstances;
        public string[] currentIrnSensors;
        public int sensorsNumber;


        public MenuManager(AgentRank rank)
        {
            this.currentIranianAgent = CreateAgent(rank);
            this.currentIrnSensors = CopyArr(currentIranianAgent.OriginalSensors);
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
                    return new FootSoldier(RandomSensorArr((int)rank));

                case AgentRank.SquadLeader:
                    return new SquadLeader(RandomSensorArr((int)rank));

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
                string sensor = GetSensor(allSensors);

                if (currentIrnSensors.Contains(sensor))
                {
                    A_Sensor activate_sensor = FindSensorInstance(sensor, this.sensorsInstances);
                    if(activate_sensor != null)
                    {
                        //this.currentIranianAgent.lastSensor = sensor;
                        activate_sensor.Active();

                    }
                    
                }
                this.currentIranianAgent.CounterAttack();
                UI.PrintHowMuchRightAnswers(currentIranianAgent.guessedRight, sensorsNumber);

            } while (currentIranianAgent.SensorsNumber != currentIranianAgent.guessedRight - currentIranianAgent.sensorExploded);

            UI.PrintFinalRes(currentIranianAgent.guessedRight, currentIranianAgent.SensorsNumber);
            currentIranianAgent.Expose();
            UI.PrintWonAndExit();
        }
            
            
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


        // create a random rank/sensors array
        static AgentRank RandomIranianAgentRanks()
        {
            Random rand = new Random();
            int index = rand.Next(allRanks.Length);
            AgentRank randomRank = allRanks[index];
            return randomRank;
        }
        public static string[] RandomSensorArr(int selfSensorNumber)
        {
            Random rand = new Random();

            string[] randomSensorsArr = new string[selfSensorNumber];

            int index;
            for (int i=0; i<selfSensorNumber; i++)
            {
                index = rand.Next(allSensors.Length);
                randomSensorsArr[i] = allSensors[index];
            }

            return randomSensorsArr;
        }



        // deep copy for an array
        public static string[] CopyArr(string[] arr)
        {
            string[] newArr = new string[arr.Length];
            int i = 0;
            foreach(string str in  arr)
            {
                newArr[i] = str;
                i++;
            }
            return newArr;
        }


        // get and validate the sensor from user
        static string GetSensor(string[] allNames)
        {
            string sensor = Console.ReadLine().ToLower();

            while (!allNames.Contains(sensor) || sensor == null)
            {
                UI.PrintWrongSensor();
                sensor = Console.ReadLine().ToLower();
            }
            return sensor;
        }


        // check if two arrays equals in theirs content
        static bool IfArrEqual(string[] arr1, string[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                return false;
            }
            for(int i=0; i< arr1.Length; i++)
            {
                if(arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }

        // dictionary keys to array
        static string[] DictionaryKToArr(Dictionary<string, A_Sensor> dict)
        {
            string[] arr = new string[dict.Count];
            int i = 0;
            foreach(string key in dict.Keys)
            {
                arr[i] = key;
                i++;
            }
            return arr;
        }
        
        static bool IfArrEmpty(string[] arr)
        {
            foreach(string val in arr)
            {
                if (!string.IsNullOrEmpty(val))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
