using GraphqlNet.Api.Enums;

namespace GraphqlNet.Api.Models;

public class Book
{
    public Guid ID { get; set; }
    public required string Title { get; set; }
    public GenreEnum Genre { get; set; }
    public Guid AuthorID { get; set; }

    public required Author Author { get; set; }
    public ICollection<BookReview> BookReviews { get; set; } = [];
    public ICollection<BookEdition> BookEditions { get; set; } = [];
}
