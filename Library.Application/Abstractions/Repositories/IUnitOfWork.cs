using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Abstractions.Repositories;

public interface IUnitOfWork
{
    IBookRepository Books { get; }
    IBorrowedBookRepository BorrowedBooks { get; }
}
