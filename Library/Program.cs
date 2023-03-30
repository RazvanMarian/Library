using Library.Application.Abstractions.Repositories;
using Library.Application.Abstractions.Services;
using Library.Application.Implementations.Services;
using Library.Infrastructure.Implementations;
using Library.UserInterface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder().ConfigureServices(
        services =>
        {
            services.AddSingleton<ILibraryService, LibraryService>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
        }).Build();


var libraryService = host.Services.GetRequiredService<ILibraryService>();

while (true)
{
    Menu.DrawMenu();

    switch (Menu.GetOption())
    {
        case MenuOption.ADD_BOOK:
            {
                var book = Menu.GetBookFromKeyboard();
                if (book != null)
                {
                    if (libraryService.AddBook(new Library.Core.Domain.Book
                    {
                        Name = book.Name,
                        ISBN = book.ISBN,
                        Price = book.Price,
                        Copies = book.Copies,
                        CurrentCopies = book.Copies
                    }) == false)
                        Console.WriteLine("A book with the specifiec ISBN already exists...");
                    else
                        Console.WriteLine("The book was succesfully added!");
                }

                break;
            }
        case MenuOption.BORROW_BOOK:
            {
                var borrowedBook = Menu.GetBorrowedBookFromKeyboard();
                if(borrowedBook != null)
                {
                    if(libraryService.BorrowBook(borrowedBook.ISBN, borrowedBook.PersonId) == false)
                        Console.WriteLine("An error occured while trying to borrow the book...");
                    else
                        Console.WriteLine("The book was succesfully borrowed!");
                }

                break;
            }
        case MenuOption.RETURN_BOOK:
            {
                var borrowedBook = Menu.GetBorrowedBookFromKeyboard();
                if (borrowedBook != null)
                {
                    var price = libraryService.ReturnBook(borrowedBook.ISBN, borrowedBook.PersonId);
                    if (price == 0)
                        Console.WriteLine("The selected book is not borrowed!");
                    else
                    {
                        Console.WriteLine("The book was succesfully returned!");
                        Console.WriteLine($"Total price: {price:C}");
                    }
                }

                break;
            }
        case MenuOption.GET_ALL_BOOKS:
            {
                Menu.ShowAllBooks(libraryService.GetAllBooks());
                break;
            }
        case MenuOption.GET_PERSONS_BORROWED_BOOKS:
            {
                Console.Write("Enter person's ID: ");
                var personID = Console.ReadLine()?.Trim() ?? string.Empty;

                Menu.ShowPersonsBorrowedBooks(libraryService.GetPersonsBorrowedBooks(personID));
                break;
            }
        case MenuOption.GET_BOOK_COPIES_NO:
            {
                Console.Write("Enter book's ISBN: ");
                var bookISBN = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(bookISBN) || bookISBN.Length <= 3 || bookISBN.Length>= 13)
                    Console.WriteLine("In order to get the number of copies of a book you must enter a valid ISBN");

                Console.WriteLine($"The number of available copies for the book with the ISBN: {bookISBN}" +
                    $" is: {libraryService.GetBookCopiesCount(bookISBN)}");

                break;
            }
        case MenuOption.CLEAR:
            {
                Console.Clear();
                break;
            }
        case MenuOption.Exit:
            {
                return;
            }
        default:
            {
                Console.WriteLine("You have chosen an invalid option!");
                break;
            }
    }
}