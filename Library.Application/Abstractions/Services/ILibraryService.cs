using Library.Core.Domain;

namespace Library.Application.Abstractions.Services;

public interface ILibraryService
{
    bool AddBook(Book book);
    bool BorrowBook(Book book, string personId);
    bool ReturnBook(BorrowedBook borrowedBook);



    int GetBookCopiesCount(string isbn);
    List<Book> GetAllBooks();
}
