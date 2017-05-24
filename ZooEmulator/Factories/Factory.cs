using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooEmulator.Animals;

namespace ZooEmulator.Factories
{
    //abstract class Factory
    //{
    //    public abstract Animal Create(string name);
    //}

    class LionFactory : IFactory
    {
        public Animal Create(string name) { return new Lion(name); }
    }

    class TigerFactory : IFactory
    {
        public Animal Create(string name) { return new Tiger(name); }
    }

    class ElephantFactory : IFactory
    {
        public Animal Create(string name) { return new Elephant(name); }
    }

    class BearFactory : IFactory
    {
        public Animal Create(string name) { return new Bear(name); }
    }

    class WolfFactory : IFactory
    {
        public Animal Create(string name) { return new Wolf(name); }
    }

    class FoxFactory : IFactory
    {
        public Animal Create(string name) { return new Fox(name); }
    }
}
