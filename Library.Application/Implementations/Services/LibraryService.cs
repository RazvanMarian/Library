using Library.Application.Abstractions.Repositories;
using Library.Application.Abstractions.Services;
using Library.Core.Domain;

namespace Library.Application.Implementations.Services;

public class LibraryService : ILibraryService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly int MAX_BORROW_PERIOD = 14;
    private readonly decimal DELAY_PENALTY = 0.01m;

    public LibraryService(IUnitOfWork _unitOfWork)
        => unitOfWork = _unitOfWork;
    
    public bool AddBook(Book book)
        => unitOfWork.Books.Add(book) != null;

    public List<Book> GetAllBooks()
        => unitOfWork.Books.GetAll();

    public int GetBookCopiesCount(string isbn)
        => unitOfWork.Books.Get(isbn)?.CurrentCopies ?? -1;

    public bool BorrowBook(string isbn, string personId)
    {
        var book = unitOfWork.Books.Get(isbn);
        if(book is null) return false;
        if(book.CurrentCopies <= 0 ) return false;

        var existingBorrowedBook = unitOfWork.BorrowedBooks.GetPersonsBorrowedBook(isbn, personId);
        if(existingBorrowedBook is not null) return false;

        var borrowedBook = new BorrowedBook
        {
            Book = book,
            Price = book.Price,
            PersonId = personId,
            BorrowedTimeStamp = DateTime.Now,
            ReturnedTimeStamp = null,
            ID = GenerateBorrowedBookId() 
        };

        if(unitOfWork.BorrowedBooks.Add(borrowedBook) is null)
            return false;

        book.CurrentCopies--;
        if(unitOfWork.Books.Update(book) is null)
            return false;

        return true;
        
    }

    public decimal ReturnBook(string isbn, string personID)
    {
        var borrowedBook = unitOfWork.BorrowedBooks.GetPersonsBorrowedBook(isbn, personID);
        if(borrowedBook is null) return 0;
        if(borrowedBook.ReturnedTimeStamp is not null) return 0;

        borrowedBook.ReturnedTimeStamp = DateTime.Now;
        unitOfWork.BorrowedBooks.Update(borrowedBook);


        var book = borrowedBook.Book;
        book.CurrentCopies++;
        unitOfWork.Books.Update(book);

        decimal finalPrice = ComputeReturnedBookPrice(borrowedBook.ReturnedTimeStamp.GetValueOrDefault(), borrowedBook.BorrowedTimeStamp, borrowedBook.Price);

        return finalPrice;
    }

    public List<BorrowedBook> GetPersonsBorrowedBooks(string personId)
         => unitOfWork.BorrowedBooks.GetPersonsBorrowedBooks(personId);


    public decimal ComputeReturnedBookPrice(DateTime ReturnedTimeStamp, DateTime BorrowedTimeStamp, decimal initialPrice)
    {
        decimal finalPrice = initialPrice;
        var days = (ReturnedTimeStamp - BorrowedTimeStamp).Days;
        if (days > MAX_BORROW_PERIOD)
            finalPrice += (days - MAX_BORROW_PERIOD) * DELAY_PENALTY * initialPrice;


        return finalPrice;
    }


    #region private
    private static int BorrowedBookIdGenerator = 1;

    private int GenerateBorrowedBookId()
        => BorrowedBookIdGenerator++;

    #endregion private
}
