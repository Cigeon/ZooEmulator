using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooEmulator.Animals
{
    class Wolf : Animal
    {
        public Wolf(string name) : base(name)
        {
            _maxHealth = 4;
            _health = _maxHealth;
        }

        public override AnimalType Type { get { return AnimalType.Wolf; } }
    }
}
