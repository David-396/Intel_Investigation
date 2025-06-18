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
    public static void Play(DAL data_base)
    {
        int turns = 0;
        int levelPassed = 0;
        float levelRank = 0;

        string username = GetUserName(data_base);

        foreach (AgentRank rank in Statics.allRanks)
        {
            MenuManager game = new MenuManager(rank);
            levelRank += game.Run();
            levelPassed++;
            turns += game.totalTurns;
        }
        data_base.AddUser(username, levelPassed, turns, levelRank / levelPassed);
        Console.WriteLine($"\nyour final average result is {levelRank / levelPassed}\nTURNS IN TOTAL - {turns}\n");

    }

    // get username and check if it doesn't exist in the database already
    public static string GetUserName(DAL db)
    {
        Console.WriteLine("enter your username: ");
        string name = Console.ReadLine();
        while ( name == null || db.IfNameExist(name))
        {
            Console.WriteLine("the name is already taken. try another name: ");
            name = Console.ReadLine();
        }
        return name;

    }



    private static void Main(string[] args)
    {
        DAL db = new DAL("sensors_investigation");
        //Console.WriteLine(db.CreateColumns());


        Play(db);
    }
}