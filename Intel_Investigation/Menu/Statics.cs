using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel_Investigation.Enums;
using Intel_Investigation.Objects;
using Intel_Investigation.Objects.Abstracts;

namespace Intel_Investigation.Menu
{
    public static class Statics
    {
        // fields to create a random rank/sensorsArr
        public static AgentRank[] allRanks = { AgentRank.FootSoldier, AgentRank.SquadLeader, AgentRank.SeniorCommander, AgentRank.OrganizationLeader };
        public static string[] allSensors = { "audio", "thermal", "pulse", "motion", "magnetic", "signal", "light"};



        // create a random rank/sensors array
        public static string[] RandomSensorArr(int selfSensorNumber, string[] allSensors)
        {
            Random rand = new Random();

            string[] randomSensorsArr = new string[selfSensorNumber];

            int index;
            for (int i = 0; i < selfSensorNumber; i++)
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
            foreach (string str in arr)
            {
                newArr[i] = str;
                i++;
            }
            return newArr;
        }


        // get and validate the sensor from user
        public static string GetSensor(string[] allNames)
        {
            string sensor = Console.ReadLine().ToLower();

            while (!allNames.Contains(sensor) || sensor == null)
            {
                UI.PrintWrongSensor();
                sensor = Console.ReadLine().ToLower();
            }
            return sensor;
        }

        // random an int
        public static int RandInt(int limit)
        {
            Random rnd = new Random();
            return rnd.Next(limit);
        }





        // returns a random agent rank
        public static AgentRank RandomIranianAgentRanks(AgentRank[] allRanks)
        {
            Random rand = new Random();
            int index = rand.Next(allRanks.Length);
            AgentRank randomRank = allRanks[index];
            return randomRank;
        }


        // check if two arrays equals in theirs content
        public static bool IfArrEqual(string[] arr1, string[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                return false;
            }
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }


        // check if all values in an array is all null
        public static bool IfArrEmpty(string[] arr)
        {
            foreach (string val in arr)
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
