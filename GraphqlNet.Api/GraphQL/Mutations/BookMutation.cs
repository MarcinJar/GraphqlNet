using GraphqlNet.Api.Data;
using GraphqlNet.Api.GraphQL.Types;
using GraphqlNet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.GraphQL.Mutations;

public partial class Mutation
{
    public async Task<Book> AddBookAsync(BookInput input, [Service] AppDbContext dbContext)
    {
        var (title, authorId, genre) = input;

        var author = await dbContext.Authors
            .FirstOrDefaultAsync(a => a.ID == input.AuthorId) ?? throw new InvalidOperationException("Author not found.");
        
        var book = new Book { 
            Title = title, 
            AuthorID = authorId, 
            Genre = genre, 
            Author = author };

        dbContext.Books.Add(book);
        await dbContext.SaveChangesAsync();

        return book;
    }
}