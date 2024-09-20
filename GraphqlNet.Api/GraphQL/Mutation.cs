using GraphQLDemo.Data;
using GraphqlNet.Api.GraphQL.Types;
using GraphqlNet.Api.Models;

namespace GraphqlNet.Api.GraphQL;

public class Mutation 
{
    public async Task<Book> AddBookAsync(BookInput input, [Service] AppDbContext context)
    {
        var (title, authorId, genre) = input;

        var author = context.Authors
            .FirstOrDefault(a => a.Id == input.AuthorId) ?? throw new InvalidOperationException("Author not found.");
        
        var book = new Book { 
            Title = title, 
            AuthorId = authorId, 
            Genre = genre, 
            Author = author };

        context.Books.Add(book);
        await context.SaveChangesAsync();

        return book;
    }

    public async Task<Author> AddAuthorAsync(string name, [Service] AppDbContext context)
    {
        var newAuthor = new Author { 
            Id = Guid.NewGuid(), 
            Name = name, 
            Books = [] 
        };

        context.Authors.Add(newAuthor);
        await context.SaveChangesAsync();

        return newAuthor;
    }
}
