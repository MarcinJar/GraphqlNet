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
    [GraphQLDescription("Add a new book")]
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

    public async Task<Book> UpdateBookTitleAsync(
        Guid bookId,
        string title, 
        [Service] AppDbContext dbContext)
    {
        var book = await dbContext.Books
            .FirstOrDefaultAsync(a => a.ID == bookId) ?? throw new InvalidOperationException("Book not found.");
        
        book.Title = title;
        dbContext.Books.Update(book);
        await dbContext.SaveChangesAsync();

        return book;
    }
}