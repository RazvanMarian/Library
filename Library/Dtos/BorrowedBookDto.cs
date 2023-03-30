using System.ComponentModel.DataAnnotations;

namespace Library.Dtos;

public class BorrowedBookDto : DtoValidator
{
    //Should be exactly 13
    //Allowed smaller for convenience
    [StringLength(13, MinimumLength = 3, ErrorMessage = "ISBN must have a value between 3 and 13 characters")]
    public required string ISBN { get; set; }

    //Should be exactly 10
    //Allowed smaller for convenience
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Person ID must have a length between 3 and 13 characters")]
    public required string PersonId { get; set;}
}
