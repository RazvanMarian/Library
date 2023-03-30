using ConsoleTables;
using Library.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Library.UserInterface;

public static class Menu
{
    public static void DrawMenu()
    {
        int index = 1;
        foreach (MenuOption option in Enum.GetValues(typeof(MenuOption))) {
            if (option == MenuOption.UNKNOWN)
                continue;
            Console.WriteLine($"{index++} - {option.GetDisplayName()}");
        }
        Console.Write("Choose an option:");
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
        if (books.Count < 0)
        {
            Console.WriteLine("There is no book available!");
            return;
        }

        ConsoleTable table = new ConsoleTable("ISBN","Name","Price","Current no. of Copies", "Total no. of Copies");

        foreach (var book in books)
            table.AddRow( book.ISBN, book.Name, book.Price, book.CurrentCopies, book.Copies);

        table.Write(Format.Alternative);
    }

    public static void ShowPersonsBorrowedBooks(List<Core.Domain.BorrowedBook> borrowedBooks)
    {
        if (borrowedBooks.Count < 0)
        {
            Console.WriteLine("The specified user doesn't have any borrowed book at the moment!");
            return;
        }

        ConsoleTable table = new ConsoleTable("ISBN", "Name", "Price");

        foreach (var borrowedBook in borrowedBooks)
            table.AddRow(borrowedBook.Book.ISBN, borrowedBook.Book.Name, borrowedBook.Book.Price);

        table.Write(Format.Alternative);
    }

    public static BookDto? GetBookFromKeyboard()
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

        var dto =  new BookDto()
        {
            Name = bookName ?? string.Empty,
            ISBN = bookISBN ?? string.Empty,
            Price = bookPrice,
            Copies = bookCopies
        };

        var errors = dto.Validate();

        if(errors.Count() > 0)
        {
            ShowErrors(errors);

            return null;
        }

        return dto;
    }

    public static BorrowedBookDto? GetBorrowedBookFromKeyboard()
    {
        Console.Write("Enter book ISBN: ");
        var bookISBN = Console.ReadLine()?.Trim();

        Console.Write("Enter person ID: ");
        var personID = Console.ReadLine()?.Trim();

        var dto = new BorrowedBookDto()
        {
            ISBN = bookISBN ?? string.Empty,
            PersonId = personID ?? string.Empty
        };

        var errors = dto.Validate();

        if (errors.Count() > 0)
        {
            ShowErrors(errors);

            return null;
        }

        return dto;
    }

    #region private
    private static void ShowErrors(List<ValidationResult> errors)
    {
        foreach (var error in errors)  Console.WriteLine(error.ToString()); 
    }
    #endregion private
}

