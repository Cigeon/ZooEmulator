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
            AddAnimalsForDebug();
        }

        private void AddAnimalsForDebug()
        {
            _animals = new List<Animal>
            {
                new Lion("Lenny"),
                new Lion("Lippy"),
                new Tiger("Tigo"),
                new Tiger("Tai"),
                new Elephant("Ellice"),
                new Elephant("Andre"),
                new Elephant("Pippo"),
                new Bear("Bonny"),
                new Bear("Claid"),
                new Wolf("Chico"),
                new Wolf("Harry"),
                new Wolf("Sonny"),
                new Fox("Jecky"),
                new Fox("Ronny")
            };

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

        // 3rd task
        public IEnumerable<IGrouping<AnimalType, Animal>> GetAnimalsGroupedByType()
        {
            return _animals.GroupBy(animal => animal.Type);
        }

        public IEnumerable<Animal> GetAnimalsByStatus(AnimalStatus status)
        {
            return _animals.Where(animal => animal.Status.Equals(status));
        }

        public IEnumerable<Animal> GetSickTigers()
        {
            return _animals.Where(animal => animal.Type.Equals(AnimalType.Tiger) &&
                        animal.Status.Equals(AnimalStatus.Sick));
        }

        public Animal GetElephantByName(string name)
        {
            return _animals.First(animal => animal.Type.Equals(AnimalType.Elephant) && 
                        animal.Name.Equals(name));
        }

        public IEnumerable<string> GetEmptyAnimalsNames()
        {
            return _animals.Where(animal => animal.Status.Equals(AnimalStatus.Empty))
                        .Select(animal => animal.Name);
        }

        public IEnumerable<Animal> GetMoreHealthyAnimalsEachType()
        {




            return _animals;
        }

        public IEnumerable<int> GetDeadAnimalsAmountEachType()
        {



            return new List<int>();
        }

        public IEnumerable<Animal> GetWolfsAndBearsHealthGt3()
        {
            return _animals.Where(animal => animal.Health > 3 &&
                        (animal.Type.Equals(AnimalType.Wolf) ||
                         animal.Type.Equals(AnimalType.Bear)));

        }

        public IEnumerable<Animal> GetAnimalsMinMaxHealth()
        {
            //var result = (from animal in _animals
            //              orderby animal.Health).ToList();

            return _animals;
            
            //var res = (_animals.OrderBy(animal => animal.Health).First()).t

            //return _animals.OrderBy(animal => animal.Health).First())
            //            .Union(_animals.OrderByDescending(animal => animal.Health)).F;
        }



        public double GetAnimalsAvgHealth()
        {
            return _animals.Average(animal => animal.Health);
        }
    }
}
