namespace GraphqlNet.Api.Models;

public class BookReview
{
    public Guid ID { get; set; }
    public Guid ReviewerID { get; set; }
    public Guid BookID { get; set; } 
    public required int Rating { get; set; }
    public required string ReviewText { get; set; }
    public DateTime ReviewDate { get; set; } = DateTime.Today;

    public required Book Book { get; set; }
    public required Reviewer Reviewer { get; set; }
}