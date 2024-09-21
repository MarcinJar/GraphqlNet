using GraphqlNet.Api.Data;
using GraphqlNet.Api.Enums;
using GraphqlNet.Api.GraphQL.Subscriptions;
using GraphqlNet.Api.Models;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.GraphQL.Mutations;

public class AddBookInput
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

public partial class Mutation
{
    public async Task<Book> AddBookAsync(
        AddBookInput input, 
        [Service] AppDbContext dbContext, 
        [Service] ITopicEventSender eventSender)
    {
        var (title, authorId, genre) = input;

        var author = await dbContext.Authors
            .FirstOrDefaultAsync(a => a.ID == input.AuthorId) ?? throw new InvalidOperationException("Author not found.");
        
        var newBook = new Book { 
            Title = title, 
            AuthorID = authorId, 
            Genre = genre, 
            Author = author };

        dbContext.Books.Add(newBook);
        await dbContext.SaveChangesAsync();

        await eventSender.SendAsync(SubscriptionEvents.OnBookAdded, newBook);

        return newBook;
    }
}