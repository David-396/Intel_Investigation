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
        static SensorType[] sensorsTypes = { SensorType.Thermal};

        static Dictionary<string, A_Sensor> sensorInstances = new Dictionary<string, A_Sensor> { { "Basic", new BasicSensor() } };

        static A_IranianAgent currentIranianAgent;
        static SensorType[] currentIrnSensors;
        static SensorType[] sensorsGuessed;
        static int sensorsNumber;
        static int rightAnswers = 0;




        // prints functions
        static void PrintMenu()
        {
            Console.WriteLine("hello!\nwelcome to the sensor guess game!\n");
        }
        static void PrintEnterIndex(int end)
        {
            Console.WriteLine($"\nenter the index of the sensor you want to guess (0 - {end}) : ");
        }
        static void PrintEnterSensor(SensorType[] sensorArr)
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
        static void PrintArr(SensorType[] arr)
        {
            foreach (SensorType obj in arr)
            {
                Console.Write(" - " + obj.ToString());
            }
            Console.WriteLine();
        }
        static void PrintRightAnswer()
        {
            Console.WriteLine("you right!");
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

                SensorType rightSensor;
                if (Enum.TryParse(sensor, out rightSensor) && rightSensor == currentIrnSensors[index])
                {
                    sensorsGuessed[index] = rightSensor;
                    rightAnswers++;
                    PrintRightAnswer();
                }

                PrintHowMuchRightAnswers();

            } while (rightAnswers != sensorsNumber);
            currentIranianAgent.Expose();
            Console.WriteLine("you won!\nbye..");

        }



        // create a random rank/sensors array
        static AgentRank RandomIranianAgentRanks()
        {
            Random rand = new Random();
            int index = rand.Next(iranianAgentRanks.Length);
            AgentRank randomRank = iranianAgentRanks[index];
            return randomRank;
        }
        static SensorType[] RandomSensorArr(int selfSensorNumber)
        {
            Random rand = new Random();
            int index = rand.Next(sensorsTypes.Length);

            SensorType[] randomSensorsArr = new SensorType[selfSensorNumber];
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
            SensorType[] sensorsArr = RandomSensorArr((int)AgentRank.FootSoldier);
            currentIranianAgent = new FootSoldier(sensorsArr);
            currentIrnSensors = sensorsArr;
            sensorsGuessed = new SensorType[sensorsArr.Length];
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
            string sensor = Console.ReadLine();

            while (!sensorInstances.ContainsKey(sensor) || sensor == null)
            {
                PrintWrongSensor();
                sensor = Console.ReadLine();
            }
            return sensor;
        }
        

    }
}
