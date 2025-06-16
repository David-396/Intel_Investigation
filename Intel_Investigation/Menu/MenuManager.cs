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
        static string[] sensorsTypes = { "basic", "thermal"};

        static Dictionary<string, A_Sensor> sensorInstances = new Dictionary<string, A_Sensor> { { "basic", new BasicSensor() },
                                                                                                 {"thermal", new ThermalSensor() } };

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
                Console.Write(" - " + str.Normalize());
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
            CreateFootSoldier();
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
            int index = rand.Next(sensorsTypes.Length);

            string[] randomSensorsArr = new string[selfSensorNumber];
            for (int i=0; i<selfSensorNumber; i++)
            {
                randomSensorsArr[i] = sensorsTypes[index];
                index = rand.Next(sensorsTypes.Length);
            }

            return randomSensorsArr;
        }


        // create an foot soldier instance
        static void CreateFootSoldier()
        {
            string[] sensorsArr = RandomSensorArr((int)AgentRank.FootSoldier);
            currentIranianAgent = new FootSoldier(sensorsArr);
            currentIrnSensors = sensorsArr;
            sensorsGuessed = new string[sensorsArr.Length];
            sensorsNumber = sensorsArr.Length;
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
        

    }
}
