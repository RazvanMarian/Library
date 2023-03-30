using Library.Core.Abstractions;

namespace Library.Core.Domain;

public class BorrowedBook : IModel
{
    public required int ID { get; set; }
    public required Book Book { get; set; }
    public required DateTime BorrowedTimeStamp { get; set; }
    public DateTime? ReturnedTimeStamp { get; set; }
    public required string PersonId { get; set; }
    public required decimal Price { get; set; }

    public string Key { get => ID.ToString(); }
}
