using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlNet.Api.Models;

public class Author
{
    public required Guid Id { get; set; }
    public required string Name { get; set; } 

    // Navigation property for one-to-many relationship
    public required List<Book> Books { get; set; }
}
