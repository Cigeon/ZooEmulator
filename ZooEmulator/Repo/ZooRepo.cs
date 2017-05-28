using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooEmulator.Animals;
using ZooEmulator.Factories;
using System.Timers;
using ZooEmulator.Engines;

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

        // Create animals for debug 
        public void AddAnimalsForDebug()
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

        // Create animal with entered name and type
        public void CreateAnimal(string name, AnimalType type)
        {
            // Check if animal with this name doesn't exist
            var exist = _animals.Where(i => i.Name == name).ToArray().Length;
            if (exist > 0)
            {
                Renderer.PrintMessage("Animal with this name already exitst!");
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
                    Renderer.PrintMessage("Couldn't create animal");
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
                Renderer.PrintMessage($"Couldn't create animal {ex.Message}");
            }
            
        }

        // Get the list of all animals
        public IEnumerable<Animal> GetAnimalList()
        {
            return _animals.OrderBy(i => i.Name);
        }

        // Get animal by name
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

        // Get random animal
        public Animal GetRandomAnimal()
        {
            if (_animals.Count > 0)
            {
                var r = new Random();
                return _animals[r.Next(0, _animals.Count)];
            }
            return null;
        }

        // Delete animal by name
        public void DeleteAnimal(string name)
        {
            try
            {
                if (_animals.Count > 0)
                {
                    var delAnimal = _animals.First(i => i.Name == name);
                    if (delAnimal.Status == AnimalStatus.Dead) _animals.Remove(delAnimal);
                    Renderer.PrintMessage($"Animal {name} deleted");
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (InvalidOperationException)
            {
                Renderer.PrintMessage($"Animal {name} doesn't exist");
            }
            
        }

        // ------------------ 3rd task ---------------------

        // Get list of animals grouped by type
        public IEnumerable<IGrouping<AnimalType, Animal>> GetAnimalsGroupedByType()
        {
            return _animals.GroupBy(animal => animal.Type);
        }

        // Get list of animals with entered status
        public IEnumerable<Animal> GetAnimalsByStatus(AnimalStatus status)
        {
            return _animals.Where(animal => animal.Status.Equals(status));
        }

        // Get list of sick tigers
        public IEnumerable<Animal> GetSickTigers()
        {
            return _animals.Where(animal => animal.Type.Equals(AnimalType.Tiger) &&
                        animal.Status.Equals(AnimalStatus.Sick));
        }

        // Get elephant by name
        public Animal GetElephantByName(string name)
        {
            return _animals.First(animal => animal.Type.Equals(AnimalType.Elephant) && 
                        animal.Name.Equals(name));
        }

        // Get names list of empty animals
        public IEnumerable<string> GetEmptyAnimalsNames()
        {
            return _animals.Where(animal => animal.Status.Equals(AnimalStatus.Empty))
                        .Select(animal => animal.Name);
        }
        
        // Get list of more healthy animal of each type
        public IEnumerable<Animal> GetMoreHealthyAnimalsEachType()
        {
            return _animals.Except(_animals.Where(animal => animal.Status.Equals(AnimalStatus.Dead)))
                            .GroupBy(animal => animal.Type)
                            .Select(group => group.OrderBy(i => i.Health).First());
        }

        // Get list of dead animals amount of each type
        public IEnumerable<KeyValuePair<AnimalType, Int32>> GetDeadAnimalsAmountEachType()
        {
            return _animals.GroupBy(animal => animal.Type)
                           .Select(animal => new KeyValuePair<AnimalType, Int32>
                                (
                                    animal.Key, 
                                    animal.Where(a => a.Status.Equals(AnimalStatus.Dead)).Count()
                                ));
        }

        // Get list of wolfs and bears that have health greater than 3 points
        public IEnumerable<Animal> GetWolfsAndBearsHealthGt3()
        {
            return _animals.Where(animal => animal.Health > 3 &&
                                 (animal.Type.Equals(AnimalType.Wolf) || animal.Type.Equals(AnimalType.Bear)));

        }
        
        // Get animals that have min and max health (2 entities)
        public IEnumerable<Animal> GetAnimalsMinMaxHealth()
        {
            return _animals.Select(i => new List<Animal>
                            {
                                _animals.Except(_animals.Where(animal => animal.Status.Equals(AnimalStatus.Dead)))
                                        .OrderBy(a => a.Health).First(),
                                _animals.Except(_animals.Where(animal => animal.Status.Equals(AnimalStatus.Dead)))
                                        .OrderByDescending(a => a.Health).First()
                            }).First();
        }

        // Get avg health value of alive animals
        public double GetAnimalsAvgHealth()
        {
            return _animals.Except(_animals.Where(animal => animal.Status.Equals(AnimalStatus.Dead)))
                           .Average(animal => animal.Health);
        }
    }
}
