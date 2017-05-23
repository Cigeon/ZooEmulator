using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooEmulator.Animals
{
    abstract class Animal
    {
        protected string _name;
        protected Status _status;
        protected int _health;
        protected int _maxHealth;
               
        public Animal(string name)
        {
            _name = name;
            _status = Status.Full;
        }

        public string Name { get { return _name; } }
        public Status Status { get { return _status; } }
        public int Health { get { return _health; } }
        public int MaxHealth { get { return _maxHealth; } }
        public abstract string AnimalType { get; }

        // Decrease animal status
        public void ChangeStatus()
        {
            if (_status > Status.Sick)
            {
                _status--;
                Console.WriteLine($"{AnimalType} {Name} status decreased to {Status}");
            }
            else
            {
                if (_health > 0)
                {
                    _health--;
                    Console.WriteLine($"{AnimalType} {Name} health decreased to {Health}");
                    if (_health == 0)
                    {
                        _status = Status.Dead;
                        Console.WriteLine($"{AnimalType} {Name} dead!!!");
                    }
                }

            }
        }

        // Feed the animal
        public void Feed()
        {
            _status = Status.Full;
            Console.WriteLine($"{AnimalType} {Name} has been feed, his status: {Status}");
        }

        // Cure the animal
        public void Cure()
        {
            if (_health < MaxHealth)
            {
                _health++;
                Console.WriteLine($"{AnimalType} {Name} has been cured, his health: {Health}");
            }

        }

    }
}
