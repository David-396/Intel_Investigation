﻿using System;
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
            Console.WriteLine("\nHELLO!\nwelcome to the sensor guess game!\n");
        }
        public static void PrintEnterSensor(string[] sensorArr)
        {
            Console.WriteLine($"\nenter the sensor you think : ");
            PrintArr(sensorArr);
        }
        public static void PrintWrongSensor()
        {
            Console.WriteLine("\nwrong sensor. please enter a valid one\n");
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
            Console.WriteLine("YOU WON!\n");
        }
        public static void PrintFinalRes(float howMuch, float from)
        {
            Console.WriteLine($"your final result is : {(howMuch/from) * 100}\n\n");
        }
    }
}
