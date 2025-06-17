using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_Investigation.Menu
{
    public static class UI
    {
        // prints functions
        public static void PrintMenu()
        {
            Console.WriteLine("hello!\nwelcome to the sensor guess game!\n");
        }
        public static void PrintEnterSensor(string[] sensorArr)
        {
            Console.WriteLine($"\nenter the sensor you think : ");
            PrintArr(sensorArr);
        }
        public static void PrintWrongSensor()
        {
            Console.WriteLine("wrong sensor. please enter a valid one ");
        }
        public static void PrintHowMuchRightAnswers(int howMuch, int from)
        {
            Console.WriteLine($"you right in {howMuch}/{from}");
        }
        public static void PrintArr(string[] arr)
        {
            foreach (string str in arr)
            {
                Console.Write(" - " + str);
            }
            Console.WriteLine();
        }
        public static void PrintRightAnswer()
        {
            Console.WriteLine("you right!");
        }
        public static void PrintWonAndExit()
        {
            Console.WriteLine("you won!\nbye..");
        }
        public static void PrintFinalRes(int howMuch, int from)
        {
            Console.WriteLine($"your final result is : {(howMuch/from) * 100}");
        }
    }
}
