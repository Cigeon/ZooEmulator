using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooEmulator.Animals;
using ZooEmulator.Factories;

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
            if (exist > 0) { Console.WriteLine("Animal with this name already exitst!"); }

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
            return _animals;
        }

        public Animal GetAnimalByName(string name)
        {
            return _animals.First(i => i.Name == name);
        }

        public void DeleteAnimal(string name)
        {
            var delAnimal = _animals.First(i => i.Name == name);
            if (delAnimal.Status == AnimalStatus.Dead) _animals.Remove(delAnimal);
        }
    }
}
