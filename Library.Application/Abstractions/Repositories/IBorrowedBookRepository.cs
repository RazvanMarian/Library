using Library.Core.Domain;

namespace Library.Application.Abstractions.Repositories;

public interface IBorrowedBookRepository : IRepository<BorrowedBook>
{
    public BorrowedBook? GetPersonsBorrowedBook(string isbn, string personId);
    public List<BorrowedBook> GetPersonsBorrowedBooks(string personId);
}
