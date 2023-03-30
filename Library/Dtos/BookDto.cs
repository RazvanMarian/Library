using System.ComponentModel.DataAnnotations;

namespace Library.Dtos;

public class BookDto : DtoValidator
{
    //Should be exactly 13
    //Allowed smaller for convenience
    [StringLength(13, MinimumLength = 3)]
    public required string ISBN { get; set; }

    [StringLength(100, MinimumLength = 3)]
    public required string Name { get; set; }

    [Range(1, maximum: int.MaxValue)]
    public required decimal Price { get; set; }

    [Range(1, maximum: int.MaxValue)]
    public required int Copies { get; set; }
}
