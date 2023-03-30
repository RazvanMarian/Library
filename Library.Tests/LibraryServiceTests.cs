namespace Library.Tests;

public class LibraryServiceTests
{
    public LibraryServiceTests() 
    {
        libraryService = new LibraryService(new UnitOfWork());

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
    public void AddBookReturnTrue()
    {
        //Arrange
        var book = books[0];

        //Act
        var response = libraryService.AddBook(book);

        //Assert
        Assert.True(response);
    }

    [Fact]
    public void AddExistingBookReturnFalse()
    {
        //Arrange
        var book = books[0];

        //Act
        var response = libraryService.AddBook(book);
        var response2 = libraryService.AddBook(book);

        //Assert
        Assert.True(response);
        Assert.False(response2);
    }

    [Fact]
    public void BorrowBookReturnTrue()
    {
        //Arrange
        var book = books[0];
        string personId = "1234";

        //Act
        libraryService.AddBook(book);
        var response2 = libraryService.BorrowBook(book.ISBN, personId);

        //Assert
        Assert.True(response2);
        Assert.Equal(9, libraryService.GetBookCopiesCount(book.ISBN));
    }

    [Fact]
    public void BorrowNonExistingBookReturnFalse()
    {
        //Arrange
        var book = books[0];
        string personId = "1234";
        string nonExistingISBN = "123";

        //Act
        libraryService.AddBook(book);
        var response2 = libraryService.BorrowBook(nonExistingISBN, personId);

        //Assert
        Assert.False(response2);
        Assert.Equal(10, libraryService.GetBookCopiesCount(book.ISBN));
    }

    [Fact]
    public void BorrowBookThatHasNoCopyLeftReturnFalse()
    {
        //Arrange
        var book = books[1];
        string personId = "1234";

        //Act
        libraryService.AddBook(book);
        var response = libraryService.BorrowBook(book.ISBN, personId);

        //Assert
        Assert.False(response);
        Assert.Equal(0, libraryService.GetBookCopiesCount(book.ISBN));
    }

    [Fact]
    public void BorrowBookThatYouAlreadyBorrowedReturnFalse()
    {
        //Arrange
        var book = books[0];
        string personId = "1234";

        //Act
        libraryService.AddBook(book);
        var response = libraryService.BorrowBook(book.ISBN, personId);
        var response2 = libraryService.BorrowBook(book.ISBN, personId);

        //Assert
        Assert.True(response);
        Assert.False(response2);
        Assert.Equal(9, libraryService.GetBookCopiesCount(book.ISBN));
    }

    [Fact]
    public void ComputeCorrectPrice()
    {
        //Arrange
        var borrowedTimeStamp = new DateTime(2023, 2, 1);
        var returnedTimeStamp = new DateTime(2023, 2, 13);
        var returnedWithPenaltyTimeStamp = new DateTime(2023, 2, 18);
        var price = 10;

        //Act
        var computedPrice = libraryService
            .ComputeReturnedBookPrice(returnedTimeStamp, borrowedTimeStamp, price);
        var computedPriceWithPenalty = libraryService
            .ComputeReturnedBookPrice(returnedWithPenaltyTimeStamp, borrowedTimeStamp, price);

        //Assert
        Assert.Equal(price, computedPrice);
        Assert.Equal(price + (price*3*0.01m), computedPriceWithPenalty);
    }

    [Fact]
    public void ReturnBookReturnTrue()
    {
        //Arrange
        var book = books[0];
        string personId = "1234";

        //Act
        libraryService.AddBook(book);
        libraryService.BorrowBook(book.ISBN, personId);
        var response = libraryService.ReturnBook(book.ISBN, personId);

        //Assert
        Assert.NotEqual(0, response);
        Assert.Equal(10, libraryService.GetBookCopiesCount(book.ISBN));
    }

    [Fact]
    public void ReturnNonExistingBookReturnFalse()
    {
        //Arrange
        var book = books[0];
        string personId = "1234";
        string nonExistingISBN = "123";

        //Act
        libraryService.AddBook(book);
        libraryService.BorrowBook(book.ISBN, personId);
        var response = libraryService.ReturnBook(nonExistingISBN, personId);

        //Assert
        Assert.Equal(0, response);
        Assert.Equal(9, libraryService.GetBookCopiesCount(book.ISBN));
    }

    [Fact]
    public void ReturnAlreadyReturnedBookReturnFalse()
    {
        //Arrange
        var book = books[0];
        string personId = "1234";

        //Act
        libraryService.AddBook(book);
        libraryService.BorrowBook(book.ISBN, personId);
        var response = libraryService.ReturnBook(book.ISBN, personId);
        var response2 = libraryService.ReturnBook(book.ISBN, personId);

        //Assert
        Assert.NotEqual(0, response);
        Assert.Equal(0, response2);
        Assert.Equal(10, libraryService.GetBookCopiesCount(book.ISBN));
    }

    [Fact]
    public void ReturnBookYouDidntBorrowReturnFalse()
    {
        //Arrange
        var book = books[0];
        string personId = "1234";
        string person2Id = "12345";

        //Act
        libraryService.AddBook(book);
        libraryService.BorrowBook(book.ISBN, person2Id);
        var response = libraryService.ReturnBook(book.ISBN, personId);

        //Assert
        Assert.Equal(0, response);
        Assert.Equal(9, libraryService.GetBookCopiesCount(book.ISBN));
    }

    [Fact]
    public void ComputeCorrectNumberOfCopies()
    {
        //Arrange
        var book = books[0];
        string personId = "1234";

        //Act
        libraryService.AddBook(book);
        libraryService.BorrowBook(book.ISBN, personId);
        var copies = libraryService.GetBookCopiesCount(book.ISBN);

        //Assert
        Assert.Equal(9, copies);
    }

    #region private
    private readonly LibraryService libraryService = null!;
    private readonly List<Book> books = null!;
    #endregion 
}