namespace Library.Tests;

public class BookRepositoryTests
{
    public BookRepositoryTests()
    {
        bookRepository = new BookRepository();
    }

    [Fact]
    public void AddBookReturnBook()
    {
        //Arrange
        var book = new Book()
        {
            ISBN = "1234",
            Name = "test book",
            Price = 10,
            Copies = 10,
            CurrentCopies = 10,
        };

        //Act
        var response = bookRepository.Add(book);

        //Assert
        Assert.NotNull(response);
    }

    [Fact]
    public void AddExistingBookReturnNull()
    {
        //Arrange
        var book = new Book()
        {
            ISBN = "1234",
            Name = "test book",
            Price = 10,
            Copies = 10,
            CurrentCopies = 10,
        };

        //Act
        var response = bookRepository.Add(book);
        var response2 = bookRepository.Add(book);

        //Assert
        Assert.NotNull(response);
        Assert.Null(response2);
    }

    [Fact]
    public void UpdateBookReturnUpdatedObject()
    {
        //Arrange
        var book = new Book()
        {
            ISBN = "1234",
            Name = "test book",
            Price = 10,
            Copies = 10,
            CurrentCopies = 10,
        };

        //Act
        var response = bookRepository.Add(book);
        book.Name= "updated book";
        var response2 = bookRepository.Update(book);

        //Assert
        Assert.NotNull(response);
        Assert.Equal("updated book",response2?.Name);
    }

    [Fact]
    public void UpdateNonExistingObjectReturnNull()
    {
        //Arrange
        var book = new Book()
        {
            ISBN = "1234",
            Name = "test book",
            Price = 10,
            Copies = 10,
            CurrentCopies = 10,
        };

        //Act
        var response = bookRepository.Update(book);

        //Assert
        Assert.Null(response);
    }

    [Fact]
    public void GetBookReturnBook()
    {
        //Arrange
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

        //Act
        bookRepository.Add(book);
        bookRepository.Add(book2);
        var finalResponse = bookRepository.Get(book2.Key);

        //Assert
        Assert.NotNull(finalResponse);
    }

    [Fact]
    public void GetNonExistingBookReturnNull()
    {
        //Arrange
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

        //Act
        bookRepository.Add(book);
        bookRepository.Add(book2);
        var finalResponse = bookRepository.Get("non-existing-isbn");

        //Assert
        Assert.Null(finalResponse);
    }

    #region private
    private readonly BookRepository bookRepository = null!;
    #endregion
}
