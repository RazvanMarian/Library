using Library.Core.Abstractions;

namespace Library.Core.Domain;

public class Book : IModel
{
    public required string ISBN { get; set; }
    public required string Name { get; set; }
    public required string Author { get; set; }
    public required decimal Price { get; set; }
    public required int Copies { get; set; }
    public required int CurrentCopies { get; set; }

    public string Key { get => ISBN; }
}
