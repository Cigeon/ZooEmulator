using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooEmulator.Animals
{
    class Lion : Animal
    {
        public Lion(string name) : base(name)
        {
            _maxHealth = 5;
            _health = _maxHealth;
        }       

        public override string AnimalType { get { return "Lion"; } }

    }
}
