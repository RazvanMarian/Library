using Library.Application.Abstractions.Repositories;
using Library.Core.Domain;
using Library.Infrastructure.Abstractions;

namespace Library.Infrastructure.Implementations;

public class BookRepository : Repository<Book>, IBookRepository
{
}
