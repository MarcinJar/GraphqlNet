using GraphqlNet.Api.Enums;

namespace GraphqlNet.Api.GraphQL.Types;

public class BookInput
{
    public required string Title { get; set; }
    public required Guid AuthorId { get; set; }
    public GenreEnum Genre { get; set; } = GenreEnum.NonFiction;

    public void Deconstruct (out string title, out Guid authorId, out GenreEnum genre)
    {
		title = Title;
		authorId = AuthorId;
		genre = Genre;
    }
}