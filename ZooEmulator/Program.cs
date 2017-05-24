using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooEmulator.Animals;
using ZooEmulator.Repo;

namespace ZooEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var zoo = new ZooRepo();

            int userInput = 0;
            do
            {
                // Clear scene and print title
                PrintTitle();

                // Get all animals
                var animals = zoo.GetAnimalList();

                // Print all animals
                Console.WriteLine($"In zoo present {animals.ToArray().Length} animals");
                Console.WriteLine();
                foreach (var item in animals)
                {
                    Console.WriteLine(item);
                }

                // Get user input command
                userInput = DisplayMainMenu();


                switch(userInput)
                {
                    case 1:
                        // Clear scene and print title
                        PrintTitle();

                        userInput = DisplaySecondMenu();

                        switch(userInput)
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
                    default:
                        break;

                }
            }
            while (userInput != 5);

        }

        static int DisplayMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Actions:");
            Console.WriteLine();
            Console.WriteLine("1. Add animal");
            Console.WriteLine("2. Feed animal");
            Console.WriteLine("3. Cure animal");
            Console.WriteLine("4. Delete animal");
            Console.WriteLine("5. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
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

            var result = Console.ReadLine();
            return Convert.ToInt32(result);
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
