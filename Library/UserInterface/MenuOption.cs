using System.ComponentModel.DataAnnotations;

namespace Library.UserInterface;

public enum MenuOption: int
{
    UNKNOWN = 0,

    [Display(Name ="Add a book")]
    ADD_BOOK = 1,

    [Display(Name = "Borrow a book")]
    BORROW_BOOK = 2,

    [Display(Name = "Return a book")]
    RETURN_BOOK = 3,

    [Display(Name = "Show all books available")]
    GET_ALL_BOOKS = 4,

    [Display(Name = "Show all borrowed books by a specific person")]
    GET_PERSONS_BORROWED_BOOKS = 5,

    [Display(Name = "Show the number of copies for a specific book")]
    GET_BOOK_COPIES_NO = 6,

    [Display(Name = "Clear")]
    CLEAR = 7,

    [Display(Name = "Exit")]
    Exit = 8,
}
