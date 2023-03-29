using Library.Application.Abstractions.Repositories;
using Library.Application.Abstractions.Services;
using Library.Core.Domain;

namespace Library.Application.Implementations.Services;

public class LibraryService : ILibraryService
{
    private readonly IUnitOfWork unitOfWork;

    public LibraryService(IUnitOfWork _unitOfWork)
    {
        this.unitOfWork = _unitOfWork;
    }

    public bool AddBook(Book book)
        => unitOfWork.Books.Add(book) != null;

    public List<Book> GetAllBooks()
        => unitOfWork.Books.GetAll();

    public int GetBookCopiesCount(string isbn)
    {
        throw new NotImplementedException();
    }

    public bool BorrowBook(Book book, string personId)
    {
        throw new NotImplementedException();
    }

    public bool ReturnBook(BorrowedBook borrowedBook)
    {
        throw new NotImplementedException();
    }
}
