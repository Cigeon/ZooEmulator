using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooEmulator.Animals
{
    class Elephant : Animal
    {
        public Elephant(string name) : base(name)
        {
            _maxHealth = 7;
            _health = _maxHealth;
        }

        public override AnimalType Type { get { return AnimalType.Elephant; } }
    }
}
