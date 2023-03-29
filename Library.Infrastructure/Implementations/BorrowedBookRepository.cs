using Library.Application.Abstractions.Repositories;
using Library.Core.Domain;
using Library.Infrastructure.Abstractions;

namespace Library.Infrastructure.Concret;

public class BorrowedBookRepository : Repository<BorrowedBook>, IBorrowedBookRepository
{
}
