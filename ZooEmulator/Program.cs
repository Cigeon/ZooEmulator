using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooEmulator.Animals;

namespace ZooEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal lion = new Fox("Reddy");
            lion.ChangeStatus();
            lion.ChangeStatus();

            lion.ChangeStatus();
            lion.ChangeStatus();
            lion.ChangeStatus();
            lion.ChangeStatus();

            lion.ChangeStatus();

            lion.Feed();
            lion.Cure();

            Animal tiger = new Tiger("dfjkdfjkdj");
            tiger.ChangeStatus();

            Console.ReadKey();
        }
    }
}
