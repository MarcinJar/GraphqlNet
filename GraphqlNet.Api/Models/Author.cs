namespace GraphqlNet.Api.Models;

public class Author
{
    public required Guid ID { get; set; }
    public Guid PersonID { get; set; }

    public required Person Person { get; set; }
    public ICollection<Book> Books { get; set; } = [];
}
