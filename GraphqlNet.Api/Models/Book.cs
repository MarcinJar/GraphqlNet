using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphqlNet.Api.Enums;

namespace GraphqlNet.Api.Models;

public class Book
{
    public Guid ID { get; set; }
    public required string Title { get; set; }
    public GenreEnum Genre { get; set; }
    public Guid AuthorId { get; set; }
    public Guid BookReviewId { get; set; }

    public required Author Author { get; set; }
    public BookReview? BookReview { get; set; }
    public List<BookEdition> BookEditions { get; set; } = [];
}
