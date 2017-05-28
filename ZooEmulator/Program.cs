using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooEmulator.Animals;
using ZooEmulator.Repo;
using ZooEmulator.Engines;
using System.Timers;
using System.Diagnostics;
//using System.Threading;

namespace ZooEmulator
{
    class Program
    {
        static void Main(string[] args)
        {           
            // Create zoo repository
            var zoo = new ZooRepo();
            zoo.AddAnimalsForDebug();

            // Create God of death :)
            var Anubis = new GodOfDeath();
            Anubis.SetWatchPeriod(5000);
            Anubis.WatchFor(zoo);
            Anubis.WakeUp();

            // Create menu and app logic
            var engine = new Engine(zoo);
            // Run app logic
            engine.Run();           

        }
    }
}
