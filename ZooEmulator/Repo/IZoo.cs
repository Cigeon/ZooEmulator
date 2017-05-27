using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooEmulator.Animals;

namespace ZooEmulator.Repo
{
    interface IZoo
    {
        void CreateAnimal(string name, AnimalType type);
        IEnumerable<Animal> GetAnimalList();
        Animal GetAnimalByName(string name);
        Animal GetRandomAnimal();
        void DeleteAnimal(string name);

        // 3rd task
        IEnumerable<IGrouping<AnimalType, Animal>> GetAnimalsGroupedByType();
        IEnumerable<Animal> GetAnimalsByStatus(AnimalStatus status);
        IEnumerable<Animal> GetSickTigers();
        Animal GetElephantByName(string name);
        IEnumerable<string> GetEmptyAnimalsNames();
        IEnumerable<Animal> GetMoreHealthyAnimalsEachType();
        IEnumerable<int> GetDeadAnimalsAmountEachType();
        IEnumerable<Animal> GetWolfsAndBearsHealthGt3();
        IEnumerable<Animal> GetAnimalsMinMaxHealth();
        double GetAnimalsAvgHealth();
    }
}
