using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooEmulator.Animals
{
    class Tiger : Animal
    {
        public Tiger(string name) : base(name)
        {
            _maxHealth = 4;
            _health = _maxHealth;
        }

        public override string AnimalType { get { return "Tiger"; } }
    }
}
