using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Intel_Investigation.Menu;
using Intel_Investigation.Enums;

internal class Program
{
    public static void Play()
    {
        MenuManager game;
        int levelPassed = 0;
        float levelRank = 0;

        foreach (AgentRank rank in Statics.allRanks)
        {
            game = new MenuManager(rank);
            levelRank += game.Run();
            levelPassed++;

        }

        Console.WriteLine($"\nyour final result is {levelRank / levelPassed}\n");

    }


    private static void Main(string[] args)
    {
        Play();
    }
}