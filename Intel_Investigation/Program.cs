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
        int turns = 0;
        int levelPassed = 0;
        float levelRank = 0;

        foreach (AgentRank rank in Statics.allRanks)
        {
            MenuManager game = new MenuManager(rank);
            levelRank += game.Run();
            levelPassed++;
            turns += game.totalTurns;
        }

        Console.WriteLine($"\nyour final result is {levelRank / levelPassed}\nTURNS IN TOTAL - {turns}");

    }


    private static void Main(string[] args)
    {
        Play();
    }
}