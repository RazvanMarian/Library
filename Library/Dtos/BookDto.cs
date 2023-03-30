using System.ComponentModel.DataAnnotations;

namespace Library.Dtos;

public class BookDto : DtoValidator
{
    //Should be exactly 13
    //Allowed smaller for convenience
    [StringLength(13, MinimumLength = 3, ErrorMessage = "ISBN must have a length between 3 and 13 characters")]
    public required string ISBN { get; set; }

    [StringLength(100, MinimumLength = 3, ErrorMessage = "ISBN must have a length between 3 and 100 characters")]
    public required string Name { get; set; }

    [StringLength(100, MinimumLength = 3, ErrorMessage = "Author name must have a length between 3 and 100 characters")]
    public required string Author { get; set; }

    [Range(1, maximum: int.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public required decimal Price { get; set; }

    [Range(0, maximum: int.MaxValue, ErrorMessage = "The number of copies must be greater or equal to 0")]
    public required int Copies { get; set; }
}
