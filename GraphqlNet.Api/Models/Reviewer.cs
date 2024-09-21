namespace GraphqlNet.Api.Models;

public class Reviewer
{
    public Guid ID { get; set; }    
    public Guid PersonID { get; set; }

    public required Person Person { get; set; }
    public ICollection<BookReview> BookReviews { get; set; } = [];
}