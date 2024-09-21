using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphqlNet.Api.Data;
using GraphqlNet.Api.GraphQL.Types;
using GraphqlNet.Api.Models;

namespace GraphqlNet.Api.GraphQL.Mutations;

public partial class Mutation
{
    public async Task<Book> AddBookAsync(BookInput input, [Service] AppDbContext context)
    {
        var (title, authorId, genre) = input;

        var author = context.Authors
            .FirstOrDefault(a => a.ID == input.AuthorId) ?? throw new InvalidOperationException("Author not found.");
        
        var book = new Book { 
            Title = title, 
            AuthorId = authorId, 
            Genre = genre, 
            Author = author };

        context.Books.Add(book);
        await context.SaveChangesAsync();

        return book;
    }
}