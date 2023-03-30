using Library.Application.Abstractions.Services;

namespace Library;

public static class Utils
{
    public static void GenerateSeedBooks(ILibraryService libraryService)
    {
        for (int i = 0; i < 5; i++)
        {
            libraryService.AddBook(new Library.Core.Domain.Book()
            {
                Name = "Book " + (i + 1).ToString(),
                ISBN = "ISBN" + (i + 1).ToString(),
                Author = "Author " + (i + 1).ToString(),
                Price = i + 1,
                Copies = i + 1,
                CurrentCopies = i + 1
            });
        }
    }
}
