using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooEmulator.Animals;
using ZooEmulator.Factories;
using System.Timers;

namespace ZooEmulator.Repo
{
    class ZooRepo : IZoo
    {
        private List<Animal> _animals;
        private IFactory _factory;

        public ZooRepo()
        {
            _animals = new List<Animal>();
        }

        public void CreateAnimal(string name, AnimalType type)
        {
            // Check if animal with this name doesn't exist
            var exist = _animals.Where(i => i.Name == name).ToArray().Length;
            if (exist > 0)
            {
                Message.GetInstance().Body = "Animal with this name already exitst!";
                return;
            }

            // Create specific factory
            switch(type)
            {
                case AnimalType.Lion:
                    _factory = new LionFactory();
                    break;
                case AnimalType.Tiger:
                    _factory = new TigerFactory();
                    break;
                case AnimalType.Elephant:
                    _factory = new ElephantFactory();
                    break;
                case AnimalType.Bear:
                    _factory = new BearFactory();
                    break;
                case AnimalType.Wolf:
                    _factory = new WolfFactory();
                    break;
                case AnimalType.Fox:
                    _factory = new FoxFactory();
                    break;
                default:
                    Console.WriteLine("Couldn't create animal");
                    break;
            }

            try
            {
                // Create animal
                var animal = _factory.Create(name);
                _animals.Add(animal);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine($"Couldn't create animal {ex.Message}");
            }
            
        }

        public IEnumerable<Animal> GetAnimalList()
        {
            return _animals.OrderBy(i => i.Name);
        }

        public Animal GetAnimalByName(string name)
        {
             if (_animals.Count > 0)
             {
                    return _animals.First(i => i.Name == name);
             }
             else
             {
                throw new InvalidOperationException();
             }           
        }

        public Animal GetRandomAnimal()
        {
            if (_animals.Count > 0)
            {
                var r = new Random();
                return _animals[r.Next(0, _animals.Count)];
            }
            return null;
        }

        public void DeleteAnimal(string name)
        {
            try
            {
                if (_animals.Count > 0)
                {
                    var delAnimal = _animals.First(i => i.Name == name);
                    if (delAnimal.Status == AnimalStatus.Dead) _animals.Remove(delAnimal);
                    Message.GetInstance().Body = $"Animal {name} deleted";
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (InvalidOperationException)
            {
                Message.GetInstance().Body = $"Animal {name} doesn't exist";
            }
            
        }
    }
}
