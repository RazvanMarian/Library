namespace Library.Tests;

public class BorrowedBookRepositoryTests
{
    public BorrowedBookRepositoryTests()
    {
        borrowedBookRepository = new BorrowedBookRepository();
    }

    [Fact]
    public void GetTheCorrectPersonsBorrowedBooks()
    {
        //Arrange
        string personId = "123";
        var book = new Book()
        {
            ISBN = "1234",
            Name = "test book",
            Price = 10,
            Copies = 10,
            CurrentCopies = 10,
        };
        var book2 = new Book()
        {
            ISBN = "12345",
            Name = "test book",
            Price = 10,
            Copies = 10,
            CurrentCopies = 10,
        };
        var borrowedBook = new BorrowedBook()
        {
            Book = book,
            ID = 1,
            BorrowedTimeStamp = DateTime.Now,
            PersonId = personId,
            Price = book.Price,
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
        var books = borrowedBookRepository.GetPersonsBorrowedBooks(personId);

        //Assert
        Assert.Equal(2, books.Count);
    }

    [Fact]
    public void GetTheCorrectPersonsBorrowedBook()
    {
        //Arrange
        string personId = "123";
        var book = new Book()
        {
            ISBN = "1234",
            Name = "test book",
            Price = 10,
            Copies = 10,
            CurrentCopies = 10,
        };
        var book2 = new Book()
        {
            ISBN = "12345",
            Name = "test book",
            Price = 10,
            Copies = 10,
            CurrentCopies = 10,
        };
        var borrowedBook = new BorrowedBook()
        {
            Book = book,
            ID = 1,
            BorrowedTimeStamp = DateTime.Now,
            PersonId = personId,
            Price = book.Price,
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
        var result = borrowedBookRepository.GetPersonsBorrowedBook(book.ISBN, personId);

        //Assert
        Assert.Equal(book.ISBN, result?.Book.ISBN);
    }

    #region private
    private readonly BorrowedBookRepository borrowedBookRepository = null!;
    #endregion
}
