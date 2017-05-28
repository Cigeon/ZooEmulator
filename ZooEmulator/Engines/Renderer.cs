using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooEmulator.Engines
{
    class Renderer
    {
        //private static readonly Renderer instance = new Renderer();
        private static int _top;
        private static int _left;
        private Renderer() { }

        public static string Message { get; set; }

        //public static Renderer GetInstance()
        //{
        //    return instance;
        //}

        // Print header at the top of the screen
        public static void PrintHeader()
        {
            // Print title
            //Console.SetCursorPosition(0, 0);
            Console.Clear();        
            Console.WriteLine("-------------------------");
            Console.WriteLine("      Zoo emulator       ");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // Print prev message
            PrintPrevMessage();
        }

        // Print message after the header
        public static void PrintMessage(string message)
        {
            // Remember message
            Message = message;

            // Remember cursor position
            _left = Console.CursorLeft;
            _top = Console.CursorTop;

            // Clear message area
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("                                                                                       ");

            // Print the message
            Console.SetCursorPosition(0, 4);
            Console.WriteLine($"Message:  {message}");

            // Set position to the previous place
            Console.SetCursorPosition(_left, _top);
        }

        // Print message again if screen was cleared
        public static void PrintPrevMessage()
        {
            PrintMessage(Message);
        }

        // Display menu and return selected command
        public static int DisplayMenu(string name, IEnumerable<string> items)
        {
            // Print menu
            Console.WriteLine(name);
            Console.WriteLine();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            try
            {
                var result = Console.ReadLine();
                var value = Convert.ToInt32(result);
                if (value < 1 || value > items.Count() + 1)
                {
                    throw new IndexOutOfRangeException();
                }
                return value;
            }
            catch (IndexOutOfRangeException)
            {
                PrintMessage($"Value not in range [1-{items.Count()}]");
            }
            catch (Exception)
            {
                PrintMessage("Wrong input");
            }
            return 0;
        }
    }
}
