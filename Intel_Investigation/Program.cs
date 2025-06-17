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
    private static void Main(string[] args)
    {
        MenuManager menu = new MenuManager(AgentRank.FootSoldier);
        menu.Run();
    }
}