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
        static AgentRank[] iranianAgentRanks = { AgentRank.FootSoldier, AgentRank.SquadLeader };


        static Dictionary<string, A_Sensor> sensorInstances = new Dictionary<string, A_Sensor> { { "basic", new BasicSensor() },
                                                                                                 {"thermal", new ThermalSensor() },
                                                                                                 {"pulse sensor", new PulseSensor() } };

        static Dictionary<AgentRank, A_IranianAgent> agentInstances = new Dictionary<AgentRank, A_IranianAgent> { { AgentRank.FootSoldier, new FootSoldier(RandomSensorArr((int)AgentRank.FootSoldier)) },
                                                                                                                  { AgentRank.SquadLeader, new SquadLeader(RandomSensorArr((int)AgentRank.SquadLeader)) } };


        static A_IranianAgent currentIranianAgent;
        static string[] currentIrnSensors;
        static string[] sensorsGuessed;
        static int sensorsNumber;
        static int rightAnswers = 0;




        // prints functions
        static void PrintMenu()
        {
            Console.WriteLine("hello!\nwelcome to the sensor guess game!\n");
        }
        static void PrintEnterIndex(int end)
        {
            Console.WriteLine($"\nenter the index of the sensor you want to guess (0 - {end - 1}) : ");
        }
        static void PrintEnterSensor(string[] sensorArr)
        {
            Console.WriteLine($"\nenter the sensor you think : ");
            PrintArr(sensorArr);
        }
        static void PrintWrongSensor()
        {
            Console.WriteLine("wrong sensor. please enter a valid one ");
        }
        static void PrintHowMuchRightAnswers()
        {
            Console.WriteLine($"you right in {rightAnswers}/{sensorsNumber}");
        }
        static void PrintArr(string[] arr)
        {
            foreach (string str in arr)
            {
                Console.Write(" - " + str);
            }
            Console.WriteLine();
        }
        static void PrintRightAnswer()
        {
            Console.WriteLine("you right!");
        }
        static void PrintWonAndExit()
        {
            Console.WriteLine("you won!\nbye..");
        }


        // main function
        public static void Run()
        {
            CreateIranAgent(AgentRank.FootSoldier);
            PrintMenu();

            do
            {
                PrintEnterIndex(sensorsNumber);
                int index = GetIndex(sensorsNumber);

                PrintEnterSensor(currentIrnSensors);
                string sensor = GetSensor();
                
                if(sensor == currentIrnSensors[index])
                {
                    if(sensor != sensorsGuessed[index])
                    {
                        sensorInstances[sensor].Active();
                        sensorsGuessed[index] = sensor;
                        rightAnswers++;
                        PrintRightAnswer();

                    }
                }
                else
                {
                    if (sensorsGuessed[index] == currentIrnSensors[index])
                    {
                        sensorsGuessed[index] = sensor;
                        if (rightAnswers > 0) rightAnswers--;
                    }
                    
                }

                PrintHowMuchRightAnswers();

            } while (!ArrEqual(currentIrnSensors, sensorsGuessed));

            currentIranianAgent.Expose();
            PrintWonAndExit();

        }



        // create a random rank/sensors array
        static AgentRank RandomIranianAgentRanks()
        {
            Random rand = new Random();
            int index = rand.Next(iranianAgentRanks.Length);
            AgentRank randomRank = iranianAgentRanks[index];
            return randomRank;
        }
        static string[] RandomSensorArr(int selfSensorNumber)
        {
            Random rand = new Random();

            string[] sensorsTypes = DictionaryKToArr(sensorInstances);

            string[] randomSensorsArr = new string[selfSensorNumber];

            int index;
            for (int i=0; i<selfSensorNumber; i++)
            {
                index = rand.Next(sensorsTypes.Length);
                randomSensorsArr[i] = sensorsTypes[index];
            }

            return randomSensorsArr;
        }


        // create an Iranian agent instance
        static void CreateIranAgent(AgentRank rank)
        {
            currentIranianAgent = agentInstances[rank];
            currentIrnSensors = currentIranianAgent.Sensors;
            sensorsGuessed = new string[currentIranianAgent.SensorsNumber];
            sensorsNumber = currentIranianAgent.SensorsNumber;
        }


        // get and validate the index from user
        static int GetIndex(int limit)
        {
            int index;
            string input = Console.ReadLine();
            while(!(int.TryParse(input, out index) && Validation.IsBetween(index, limit)))
            {
                Console.WriteLine("wrong input");
                input = Console.ReadLine();
            }
            return index;
        }
        static string GetSensor()
        {
            string sensor = Console.ReadLine().ToLower();

            while (!sensorInstances.ContainsKey(sensor) || sensor == null)
            {
                PrintWrongSensor();
                sensor = Console.ReadLine().ToLower();
            }
            return sensor;
        }


        // check if two arrays equals in theirs content
        static bool ArrEqual(string[] arr1, string[] arr2)
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
        

    }
}
