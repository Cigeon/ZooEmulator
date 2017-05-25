﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooEmulator.Animals
{
    abstract class Animal
    {
        protected string _name;
        protected AnimalStatus _status;
        protected int _health;
        protected int _maxHealth;
               
        public Animal(string name)
        {
            _name = name;
            _status = AnimalStatus.Full;
        }

        public string Name { get { return _name; } }
        public AnimalStatus Status { get { return _status; } }
        public int Health { get { return _health; } }
        public int MaxHealth { get { return _maxHealth; } }
        public abstract AnimalType Type { get; }

        // Decrease animal status
        public void ChangeStatus()
        {
            if (_status > AnimalStatus.Sick)
            {
                _status--;
                Console.WriteLine($"{Type} {Name} status decreased to {Status}");
            }
            else
            {
                if (_health > 0)
                {
                    _health--;
                    Console.WriteLine($"{Type} {Name} health decreased to {Health}");
                    if (_health == 0)
                    {
                        _status = AnimalStatus.Dead;

                        Console.WriteLine();
                        Console.WriteLine($"{Type} {Name} dead!!!");
                    }
                }

            }
        }

        // Feed the animal
        public void Feed()
        {
            if (Status != AnimalStatus.Dead)
            {
                _status = AnimalStatus.Full;
                Message.GetInstance().Body = $"{Type} {Name} has been feed, his status: {Status}";
            }
            else
            {
                Message.GetInstance().Body = $"{Type} {Name} dead you can't feed it";
            }
            
        }

        // Cure the animal
        public void Cure()
        {
            if (Status != AnimalStatus.Dead)
            {
                if (_health < MaxHealth)
                {
                    _health++;
                    Message.GetInstance().Body = $"{Type} {Name} has been cured, his health: {Health}";
                }
            }
            else
            {
                Message.GetInstance().Body = $"{Type} {Name} dead you can't cure it";
            }

        }

        public override string ToString()
        {
            return $"{Type} - name: {Name}, status: {Status}, health: {Health}";
        }

    }
}
