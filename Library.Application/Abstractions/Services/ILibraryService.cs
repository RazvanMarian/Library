using Library.Core.Domain;

namespace Library.Application.Abstractions.Services;

public interface ILibraryService
{
    bool AddBook(Book book);
    bool BorrowBook(string isbn, string personId);
    decimal ReturnBook(string isbn, string personId);
    decimal ComputeReturnedBookPrice(DateTime ReturnedTimeStamp, DateTime BorrowedTimeStamp, decimal initialPrice);
    List<BorrowedBook> GetPersonsBorrowedBooks(string personId);
    int GetBookCopiesCount(string isbn);
    List<Book> GetAllBooks();
}
