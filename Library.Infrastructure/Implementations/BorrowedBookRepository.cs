using Library.Application.Abstractions.Repositories;
using Library.Core.Domain;
using Library.Infrastructure.Abstractions;

namespace Library.Infrastructure.Implementations;

public class BorrowedBookRepository : Repository<BorrowedBook>, IBorrowedBookRepository
{
    public BorrowedBook? GetPersonsBorrowedBook(string isbn, string personId)
        => entities
                .Where(b => b.PersonId == personId)
                .Where(b => b.Book.ISBN == isbn)
                .Where(b => b.ReturnedTimeStamp == null)
                .FirstOrDefault();

    public List<BorrowedBook> GetPersonsBorrowedBooks(string personId)
        => entities
                .Where(b => b.PersonId == personId)
                .Where(b => b.ReturnedTimeStamp == null)
                .ToList();  
}
