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
                        Console.WriteLine("Eroare");
                    else
                        Console.WriteLine("Succes");
                }
                else
                    Console.WriteLine("Eroare");
                break;
            }
        case MenuOption.BORROW_BOOK:
            {
                break;
            }
        case MenuOption.RETURN_BOOK:
            {
                break;
            }
        case MenuOption.GET_ALL_BOOKS:
            {
                Menu.ShowAllBooks(libraryService.GetAllBooks());
                break;
            }
        case MenuOption.GET_BOOK_COPIES_NO:
            {
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
                Console.WriteLine("Ati ales o optiune invalida!");
                break;
            }
    }
}