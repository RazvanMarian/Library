using Library.Application.Abstractions.Repositories;

namespace Library.Infrastructure.Implementations;

public class UnitOfWork : IUnitOfWork
{
    public IBookRepository Books
    {
        get
        {
            if (books == null)
                books = new BookRepository();
            
            return books;
        }
    }

    public IBorrowedBookRepository BorrowedBooks
    {
        get
        {
            if (borrowedBooks == null)
                borrowedBooks = new BorrowedBookRepository();

            return borrowedBooks;
        }
    }


    #region private

    private IBookRepository books = null!;
    private IBorrowedBookRepository borrowedBooks = null!;

    #endregion
}
