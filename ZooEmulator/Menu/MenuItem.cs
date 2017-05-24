using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooEmulator.Menu
{
    public class MenuItem : List<MenuItem>
    {

        public string Name { get; set; }
        public Action Action { get; set; }
        public bool Marked { get; set; }
        public int SelectedIndex { get; private set; }

        public MenuItem SelectedItem => this[SelectedIndex];

        public void AddItem(MenuItem item)
        {
            this.Add(item);
        }

        public void Run()
        {
            var fColor = Console.ForegroundColor;

            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                foreach (var item in this)
                {
                    Console.ForegroundColor = fColor;
                    //show selected item
                    if (item.Marked)
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(item == SelectedItem ? item.Name.ToUpper() : item.Name);
                }
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (SelectedIndex > 0)
                            {
                                SelectedIndex--;
                            }
                            else
                            {
                                SelectedIndex = Count - 1;
                            }
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (SelectedIndex < Count - 1)
                            {
                                SelectedIndex++;
                            }
                            else
                            {
                                SelectedIndex = 0;
                            }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            SelectedItem.Action?.Invoke();
                            break;
                        }
                }
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
