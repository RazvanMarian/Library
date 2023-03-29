using System.ComponentModel.DataAnnotations;

namespace Library.UserInterface
{
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

        [Display(Name = "Shoe the number of copies for a specific book")]
        GET_BOOK_COPIES_NO = 5,

        [Display(Name = "Clear")]
        CLEAR = 6,

        [Display(Name = "Exit")]
        Exit = 7,
    }
}
