using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.GraphQL.Mutations;

public class AddBookReviewInput
{
    public Guid ReviewerID { get; set; }
    public Guid BookID { get; set; } 
    public required int Rating { get; set; }
    public required string? ReviewText { get; set; }

    public void Deconstruct (out Guid reviewerId, out Guid bookId, out int rating, out string reviewText)
    {
		reviewerId = ReviewerID;
		bookId = BookID;
        rating = Rating;
        reviewText = ReviewText ?? string.Empty;
    }
}

public partial class Mutation
{
    public async Task<BookReview> AddBookReviewAsync(AddBookReviewInput input, [Service] AppDbContext dbContext)
    {
        var (reviewerId, bookId, rating, reviewText) = input;

        var author = await dbContext.Reviewers
            .FirstOrDefaultAsync(a => a.ID == reviewerId) ?? throw new InvalidOperationException("Reviewer not found.");

        var book = await dbContext.Books
            .FirstOrDefaultAsync(a => a.ID == bookId) ?? throw new InvalidOperationException("Book not found.");
        
        var bookReview = new BookReview { 
            BookID = bookId,
            ReviewerID = reviewerId,
            Rating = rating,
            ReviewText = reviewText,
            Book = book,
            Reviewer = author };

        dbContext.BookReviews.Add(bookReview);
        await dbContext.SaveChangesAsync();

        return bookReview;
    }
}