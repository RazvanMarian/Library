using System.ComponentModel.DataAnnotations;

namespace Library.Dtos;

public class BorrowedBookDto : DtoValidator
{
    //Should be exactly 13
    //Allowed smaller for convenience
    [StringLength(13, MinimumLength = 3)]
    public required string ISBN { get; set; }

    //Should be exactly 10
    //Allowed smaller for convenience
    [StringLength(10, MinimumLength = 3)]
    public required string PersonId { get; set;}
}
