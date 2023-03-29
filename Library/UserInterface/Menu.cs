using Library.Core.Domain;
using Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            foreach (MenuOption option in Enum.GetValues(typeof(MenuOption))) {
                if (option == MenuOption.UNKNOWN)
                    continue;
                Console.WriteLine($"{index++} - {option.GetDisplayName()}");
            }
        }

        public static MenuOption GetOption()
        {
            if (Enum.TryParse(Console.ReadLine(), out MenuOption option))
                return option;
            else
                return MenuOption.UNKNOWN;
        }

        public static void ShowAllBooks(List<Core.Domain.Book> books)
        {
            foreach(var book in books)
            {
                Console.WriteLine("|{0,5}|{1,5}|{2,5}|{3,5}|", book.ISBN, book.Name, book.Price, book.Copies);
            }
        }

        public static Models.Book GetBookFromKeyboard()
        {
            Console.Write("Enter book name: ");
            var bookName = Console.ReadLine()?.Trim();

            Console.Write("Enter book ISBN: ");
            var bookISBN = Console.ReadLine()?.Trim();


            Console.Write("Enter rent price: ");
            var price = Console.ReadLine()?.Trim();
            decimal.TryParse(price, out decimal parsedPrice);
            var bookPrice = parsedPrice;

            Console.Write("Enter quantity: ");
            var copies = Console.ReadLine()?.Trim();
            int.TryParse(copies, out int parsedCopies);
            var bookCopies = parsedCopies;

            return new Models.Book()
            {
                Name = bookName,
                ISBN = bookISBN,
                Price = bookPrice,
                Copies = bookCopies
            };
        }
    }
}

