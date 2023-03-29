using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UserInterface
{
    public static class Menu
    {
        public static void DrawMenu()
        {
            Console.WriteLine("Alege o optiune:");
            int index = 1;
            foreach(MenuOption option in Enum.GetValues(typeof(MenuOption)))
                Console.WriteLine($"{index++} - {option.GetDisplayName()}");
        }
    }
}
