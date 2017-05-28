using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooEmulator.Animals;
using ZooEmulator.Repo;
using System.Timers;
using System.Diagnostics;
//using System.Threading;

namespace ZooEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool allAnimalsDead = false;    // Flag to display message

            // Create zoo repository
            var zoo = new ZooRepo();

            //Create God of death
            var Anubis = new Timer(5000);
            Anubis.Elapsed += (sender, e) => TouchSomebody(sender, e, zoo);
            Anubis.Enabled = true;

            int userInput = 0;
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


                // Clear scene and print title
                PrintTitle();

                // Print message
                Console.WriteLine(Message.GetInstance().Body);
                Console.WriteLine();

                // Display menu and get user input 
                userInput = DisplayMainMenu();

                // Exit command
                if (userInput == 6) break;

                try
                {
                    switch (userInput)
                    {
                        case 1:
                            // Clear scene and print title
                            PrintTitle();

                            // Display menu and get user input 
                            userInput = DisplaySecondMenu();

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

                            // Clear scene and print title
                            PrintTitle();

                            // Display menu and get user input 
                            userInput = Display3rdMenu();

                            switch (userInput)
                            {
                                case 1:
                                    // Clear scene and print title
                                    PrintTitle();
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
                                    // Clear scene and print title
                                    PrintTitle();

                                    // Display menu and get user input 
                                    userInput = DisplayStatusMenu();

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

                                    // Clear scene and print title
                                    PrintTitle();
                                    Console.WriteLine($"Animals that have specified status:");
                                    zoo.GetAnimalsByStatus(status).ToList()
                                        .ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;
                                case 3:
                                    // Clear scene and print title
                                    PrintTitle();
                                    Console.WriteLine($"Sick tigers:");
                                    zoo.GetSickTigers().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;
                                case 4:
                                    // Clear scene and print title
                                    PrintTitle();
                                    Console.WriteLine($"Show elephant by name:");
                                    Console.WriteLine(zoo.GetElephantByName(Console.ReadLine()));

                                    Console.ReadKey();
                                    break;
                                case 5:
                                    // Clear scene and print title
                                    PrintTitle();
                                    Console.WriteLine($"List of empty animals names:");
                                    zoo.GetEmptyAnimalsNames().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;
                                case 6:
                                    // Clear scene and print title
                                    PrintTitle();
                                    Console.WriteLine($"More healthy animals of each type:");
                                    zoo.GetMoreHealthyAnimalsEachType().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;
                                case 7:
                                    // Clear scene and print title
                                    PrintTitle();
                                    Console.WriteLine($"Dead animals:");
                                    zoo.GetDeadAnimalsAmountEachType().ToList().ForEach(i => Console.WriteLine($"{i.Key}: {i.Value}"));

                                    Console.ReadKey();
                                    break;
                                case 8:
                                    // Clear scene and print title
                                    PrintTitle();
                                    Console.WriteLine($"Wolfs and bears that have health > 3:");
                                    zoo.GetWolfsAndBearsHealthGt3().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;
                                case 9:
                                    // Clear scene and print title
                                    PrintTitle();
                                    Console.WriteLine($"Animals that have min and max health:");
                                    zoo.GetAnimalsMinMaxHealth().ToList().ForEach(i => Console.WriteLine(i));

                                    Console.ReadKey();
                                    break;
                                case 10:
                                    // Clear scene and print title
                                    PrintTitle();
                                    Console.WriteLine($"Avg health in the zoo:");
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
                    Message.GetInstance().Body = $"Animal you specify doesn't exist";
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

        static int DisplayMainMenu()
        {
            Console.WriteLine("Actions:");
            Console.WriteLine();
            Console.WriteLine("1. Add animal");
            Console.WriteLine("2. Feed animal");
            Console.WriteLine("3. Cure animal");
            Console.WriteLine("4. Delete animal");
            Console.WriteLine("5. Show animals");
            Console.WriteLine("6. Exit");
            Console.WriteLine();

            try
            {
                var result = Console.ReadLine();
                var value = Convert.ToInt32(result);
                if (value < 1 || value > 5)
                {
                    throw new IndexOutOfRangeException();
                }
                return value;
            }
            catch (IndexOutOfRangeException)
            {
                Message.GetInstance().Body = "Value not in range [1-5]";
            }
            catch (Exception)
            {
                Message.GetInstance().Body = "Wrong input";
            }
            return 0;
        }

        static int DisplaySecondMenu()
        {
            Console.WriteLine("Choose animal type:");
            Console.WriteLine();
            Console.WriteLine("1. Lion");
            Console.WriteLine("2. Tiger");
            Console.WriteLine("3. Elephant");
            Console.WriteLine("4. Bear");
            Console.WriteLine("5. Wolf");
            Console.WriteLine("6. Fox");
            Console.WriteLine("7. Back to prev menu");
            Console.WriteLine();

            try
            {
                var result = Console.ReadLine();
                var value = Convert.ToInt32(result);
                if (value < 1 || value > 7)
                {
                    throw new IndexOutOfRangeException();
                }
                return value;
            }
            catch (IndexOutOfRangeException)
            {
                Message.GetInstance().Body = "Value not in range [1-7]";
            }
            catch (Exception)
            {
                Message.GetInstance().Body = "Wrong input";
            }
            return 0;
        }

        static int Display3rdMenu()
        {
            Console.WriteLine("Show:");
            Console.WriteLine();
            Console.WriteLine("1. Animals grouped by type");
            Console.WriteLine("2. Animals by status");
            Console.WriteLine("3. All sick tigers");
            Console.WriteLine("4. Elephant by name");
            Console.WriteLine("5. Names of empty animals");
            Console.WriteLine("6. More healthy animals of the each type");
            Console.WriteLine("7. Dead animals amount of the each type");
            Console.WriteLine("8. Wolfs and bears health that have health > 3");
            Console.WriteLine("9. Animals that have min and max health");
            Console.WriteLine("10. Average health of all animal");
            Console.WriteLine("11. Back to prev menu");
            Console.WriteLine();

            try
            {
                var result = Console.ReadLine();
                var value = Convert.ToInt32(result);
                if (value < 1 || value > 11)
                {
                    throw new IndexOutOfRangeException();
                }
                return value;
            }
            catch (IndexOutOfRangeException)
            {
                Message.GetInstance().Body = "Value not in range [1-11]";
            }
            catch (Exception)
            {
                Message.GetInstance().Body = "Wrong input";
            }
            return 0;
        }

        static int DisplayStatusMenu()
        {
            Console.WriteLine("Choose a status:");
            Console.WriteLine();
            Console.WriteLine("1. Full");
            Console.WriteLine("2. Empty");
            Console.WriteLine("3. Sick");
            Console.WriteLine("4. Dead");
            Console.WriteLine("5. Back to prev menu");
            Console.WriteLine();

            try
            {
                var result = Console.ReadLine();
                var value = Convert.ToInt32(result);
                if (value < 1 || value > 5)
                {
                    throw new IndexOutOfRangeException();
                }
                return value;
            }
            catch (IndexOutOfRangeException)
            {
                Message.GetInstance().Body = "Value not in range [1-5]";
            }
            catch (Exception)
            {
                Message.GetInstance().Body = "Wrong input";
            }
            return 0;
        }

        private static void TouchSomebody(object source, ElapsedEventArgs e, ZooRepo zoo)
        {
            var victim = zoo.GetRandomAnimal();
            if (victim != null)
            {
                victim.ChangeStatus();
            }
        }

        static void PrintTitle()
        {
            // Clear scene and print title
            Console.Clear();
            Console.WriteLine("Zoo emulator");
            Console.WriteLine("------------");
            Console.WriteLine();
        }
    }
}
