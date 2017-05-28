using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooEmulator.Animals;
using ZooEmulator.Repo;

namespace ZooEmulator.Engines
{
    class Engine
    {
        private ZooRepo zoo;
        public Engine(ZooRepo zoo)
        {
            this.zoo = zoo;
        }

        public void Run()
        {
            bool allAnimalsDead = false;    // Flag to display message
            int userInput = 0;              // User input command

            do
            {
                // Check if any animal alive
                var animals = zoo.GetAnimalList();
                if (animals.ToArray().Length > 0)
                {
                    var deadAnimals = animals.Where(i => i.Status.Equals(AnimalStatus.Dead));
                    if (animals.ToArray().Length == deadAnimals.ToArray().Length)
                    {
                        allAnimalsDead = true;
                        break;
                    }
                }

                // Print header
                Renderer.PrintHeader();

                // Print menu
                userInput = Renderer.DisplayMenu("Actions:", new List<string>
                                                        {
                                                            "1. Add animal",
                                                            "2. Feed animal",
                                                            "3. Cure animal",
                                                            "4. Delete animal",
                                                            "5. Show animals",
                                                            "6. Exit"
                                                        });


                // Exit command
                if (userInput == 6) break;

                try
                {
                    // Print header
                    Renderer.PrintHeader();

                    switch (userInput)
                    {
                        case 1:

                            // Print menu
                            userInput = Renderer.DisplayMenu("Choose animal type:", new List<string>
                                                                {
                                                                    "1. Lion",
                                                                    "2. Tiger",
                                                                    "3. Elephant",
                                                                    "4. Bear",
                                                                    "5. Wolf",
                                                                    "6. Fox",
                                                                    "Press any key back to prev menu"
                                                                });

                            // Print header
                            Renderer.PrintHeader();

                            switch (userInput)
                            {
                                case 1:
                                    Console.WriteLine($"Type lion name to create:");
                                    zoo.CreateAnimal(Console.ReadLine(), AnimalType.Lion);
                                    break;
                                case 2:
                                    Console.WriteLine($"Type tiger name to create:");
                                    zoo.CreateAnimal(Console.ReadLine(), AnimalType.Tiger);
                                    break;
                                case 3:
                                    Console.WriteLine($"Type elephant name to create:");
                                    zoo.CreateAnimal(Console.ReadLine(), AnimalType.Elephant);
                                    break;
                                case 4:
                                    Console.WriteLine($"Type bear name to create:");
                                    zoo.CreateAnimal(Console.ReadLine(), AnimalType.Bear);
                                    break;
                                case 5:
                                    Console.WriteLine($"Type wolf name to create:");
                                    zoo.CreateAnimal(Console.ReadLine(), AnimalType.Wolf);
                                    break;
                                case 6:
                                    Console.WriteLine($"Type fox name to create:");
                                    zoo.CreateAnimal(Console.ReadLine(), AnimalType.Fox);
                                    break;
                                default:
                                    break;
                            }

                            userInput = 0;
                            break;

                        case 2:
                            Console.WriteLine($"Type animal name to feed:");
                            var feedAnimal = zoo.GetAnimalByName(Console.ReadLine());
                            feedAnimal.Feed();
                            break;
                        case 3:
                            Console.WriteLine($"Type animal name to cure:");
                            var cureAnimal = zoo.GetAnimalByName(Console.ReadLine());
                            cureAnimal.Cure();
                            break;
                        case 4:
                            Console.WriteLine($"Type animal name to delete:");
                            zoo.DeleteAnimal(Console.ReadLine());
                            break;
                        case 5:

                            // Print menu
                            userInput = Renderer.DisplayMenu("Show:", new List<string>
                                                            {
                                                                "1. Animals grouped by type",
                                                                "2. Animals by status",
                                                                "3. All sick tigers",
                                                                "4. Elephant by name",
                                                                "5. Names of empty animals",
                                                                "6. More healthy animals of the each type",
                                                                "7. Dead animals amount of the each type",
                                                                "8. Wolfs and bears health that have health > 3",
                                                                "9. Animals that have min and max health",
                                                                "10. Average health of all animal",
                                                                "Press any key back to prev menu"
                                                            });

                            // Print header
                            Renderer.PrintHeader();

                            switch (userInput)
                            {
                                case 1:

                                    Console.WriteLine($"Animals grouped by type:");
                                    zoo.GetAnimalsGroupedByType().ToList()
                                        .ForEach(g =>
                                        {
                                            Console.WriteLine($"Group {g.Key}");
                                            g.ToList().ForEach(i => Console.WriteLine(i));
                                        });

                                    Console.ReadKey();
                                    break;

                                case 2:

                                    // Print menu
                                    userInput = Renderer.DisplayMenu("Choose animal status:", new List<string>
                                                                {
                                                                    "1. Full",
                                                                    "2. Empty",
                                                                    "3. Sick",
                                                                    "4. Dead",
                                                                    "Press any key back to prev menu"
                                                                });

                                    // Print header
                                    Renderer.PrintHeader();

                                    var status = new AnimalStatus();

                                    switch (userInput)
                                    {
                                        case 1:
                                            status = AnimalStatus.Full;
                                            break;
                                        case 2:
                                            status = AnimalStatus.Empty;
                                            break;
                                        case 3:
                                            status = AnimalStatus.Sick;
                                            break;
                                        case 4:
                                            status = AnimalStatus.Dead;
                                            break;
                                        default:
                                            break;
                                    }

                                    Console.WriteLine($"Animals with selected status:");

                                    zoo.GetAnimalsByStatus(status).ToList()
                                        .ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;

                                case 3:

                                    Console.WriteLine($"Sick tigers:");

                                    zoo.GetSickTigers().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;

                                case 4:

                                    Console.WriteLine($"Show elephant by name:");

                                    Console.WriteLine(zoo.GetElephantByName(Console.ReadLine()));

                                    Console.ReadKey();
                                    break;

                                case 5:

                                    Console.WriteLine($"List of empty animals names:");

                                    zoo.GetEmptyAnimalsNames().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;

                                case 6:

                                    Console.WriteLine($"More healthy animals of each type:");

                                    zoo.GetMoreHealthyAnimalsEachType().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;

                                case 7:

                                    Console.WriteLine($"Dead animals amount of each group:");

                                    zoo.GetDeadAnimalsAmountEachType().ToList().ForEach(i => Console.WriteLine($"{i.Key}: {i.Value}"));

                                    Console.ReadKey();
                                    break;

                                case 8:

                                    Console.WriteLine($"Wolfs and bears that have health greater than 3 points:");

                                    zoo.GetWolfsAndBearsHealthGt3().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;

                                case 9:

                                    Console.WriteLine($"Animals that have min and max health:");

                                    zoo.GetAnimalsMinMaxHealth().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;

                                case 10:

                                    Console.WriteLine($"Avg health of alive animals:");

                                    Console.WriteLine(zoo.GetAnimalsAvgHealth());

                                    Console.ReadKey();
                                    break;
                                default:
                                    break;
                            }

                            userInput = 0;
                            break;

                        default:
                            break;

                    }

                }
                catch (InvalidOperationException)
                {
                    Renderer.PrintMessage("Animal you specify doesn't exist");
                }


            }
            while (true);

            // Show message if all animals are dead
            if (allAnimalsDead)
            {
                Console.Clear();
                Console.WriteLine("There are any alive animal in the zoo!");
                Console.ReadKey();
            }
        }
    }
}
