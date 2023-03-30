namespace Library.Tests;

public class BorrowedBookRepositoryTests
{
    public BorrowedBookRepositoryTests()
    {
        borrowedBookRepository = new BorrowedBookRepository();

        books = new List<Book>()
        {
            new Book()
            {
                ISBN = "1234",
                Name = "test book",
                Author = "test author",
                Price = 10,
                Copies = 10,
                CurrentCopies = 10,
            },
            new Book()
            {
                ISBN = "12345",
                Name = "test book 2",
                Author = "test author 2",
                Price = 10,
                Copies = 10,
                CurrentCopies = 0,
            },
        };
    }

    [Fact]
    public void GetTheCorrectPersonsBorrowedBooks()
    {
        //Arrange
        string personId = "123";
        var book1 = books[0];
        var book2 = books[1];
        
        var borrowedBook = new BorrowedBook()
        {
            Book = book1,
            ID = 1,
            BorrowedTimeStamp = DateTime.Now,
            PersonId = personId,
            Price = book1.Price,
        };
        var borrowedBook2 = new BorrowedBook()
        {
            Book = book2,
            ID = 2,
            BorrowedTimeStamp = DateTime.Now,
            PersonId = personId,
            Price = book2.Price,
        };
        var borrowedBook3 = new BorrowedBook()
        {
            Book = book2,
            ID = 3,
            BorrowedTimeStamp = DateTime.Now,
            PersonId = "another_id",
            Price = book2.Price,
        };

        //Act
        borrowedBookRepository.Add(borrowedBook);
        borrowedBookRepository.Add(borrowedBook2);
        borrowedBookRepository.Add(borrowedBook3);
        var borrowedBooks = borrowedBookRepository.GetPersonsBorrowedBooks(personId);

        //Assert
        Assert.Equal(2, borrowedBooks.Count);
    }

    [Fact]
    public void GetTheCorrectPersonsBorrowedBook()
    {
        //Arrange
        string personId = "123";
        var book1 = books[0];
        var book2 = books[1];

        var borrowedBook = new BorrowedBook()
        {
            Book = book1,
            ID = 1,
            BorrowedTimeStamp = DateTime.Now,
            PersonId = personId,
            Price = book1.Price,
        };
        var borrowedBook2 = new BorrowedBook()
        {
            Book = book2,
            ID = 2,
            BorrowedTimeStamp = DateTime.Now,
            PersonId = personId,
            Price = book2.Price,
        };

        //Act
        borrowedBookRepository.Add(borrowedBook);
        borrowedBookRepository.Add(borrowedBook2);
        var result = borrowedBookRepository.GetPersonsBorrowedBook(book1.ISBN, personId);

        //Assert
        Assert.Equal(book1.ISBN, result?.Book.ISBN);
    }

    #region private
    private readonly BorrowedBookRepository borrowedBookRepository = null!;
    private readonly List<Book> books = null!;
    #endregion
}
