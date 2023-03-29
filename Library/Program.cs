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


//var libraryService = host.Services.GetRequiredService<ILibraryService>();

//libraryService.AddBook(new Library.Core.Domain.Book()
//    { 
//        Name="testName",
//        ISBN="test",
//        Price=1,
//        Copies=1,
//        CurrentCopies=1,
//    });

//Console.WriteLine(libraryService.GetAllBooks().FirstOrDefault().Name);

Menu.DrawMenu();