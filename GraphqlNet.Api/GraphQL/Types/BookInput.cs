using GraphqlNet.Api.Enums;

namespace GraphqlNet.Api.GraphQL.Types;

public class BookInput
{
    public required string Title { get; set; }
    public required Guid AuthorId { get; set; }
    public Genre Genre { get; set; } = Genre.NonFiction;

    public void Deconstruct (out string title, out Guid authorId, out Genre genre)
    {
      title = Title;
      authorId = AuthorId;
      genre = Genre;
    }
}