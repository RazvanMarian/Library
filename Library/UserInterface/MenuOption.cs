using System.ComponentModel.DataAnnotations;

namespace Library.UserInterface
{
    public enum MenuOption: int
    {
        [Display(Name ="Adauga o carte")]
        ADD_BOOK = 1,

        [Display(Name = "Imprumuta o carte")]
        BORROW_BOOK = 2,

        [Display(Name = "Returneaza o carte")]
        RETURN_BOOK = 3,

        [Display(Name = "Afiseaza toate cartile")]
        GET_ALL_BOOKS = 4,

        [Display(Name = "Returneaza o carte")]
        GET_BOOK_COPIES_NO = 5,
    }
}
