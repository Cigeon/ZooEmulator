using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooEmulator.Animals;
using ZooEmulator.Repo;
using ZooEmulator.Menu;

namespace ZooEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var zoo = new ZooRepo();

            // Create menu
            var menu = new MenuItem
            { 
                new MenuItem
                {
                    Name = "Create animal",
                    Action = () => Console.WriteLine("create")
                },
                new MenuItem
                {
                    Name = "Delete animal",
                    Action = () => Console.WriteLine("delete")
                }
            };
            //run menu
            menu.Run();

        }
    }
}
