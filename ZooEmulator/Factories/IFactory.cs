using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooEmulator.Animals;

namespace ZooEmulator.Factories
{
    interface IFactory
    {
        Animal Create(string name);
    }
}
