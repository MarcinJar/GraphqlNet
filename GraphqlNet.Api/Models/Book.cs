using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphqlNet.Api.Enums;

namespace GraphqlNet.Api.Models;

public class Book
{
    public Guid Id { get; set; }
    public required string Title { get; set; }

    // Foreign key to the Author
    public Guid AuthorId { get; set; }
    public Author? Author { get; set; }
    public Genre Genre { get; set; }
}
