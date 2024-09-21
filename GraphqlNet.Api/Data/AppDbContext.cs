// Data/AppDbContext.cs
using GraphqlNet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Reviewer> Reviewers { get; set; }
    public DbSet<BookReview> BookReviews { get; set; }
    public DbSet<BookEdition> BookEditions { get; set; }
    public DbSet<PublishingHouse> PublishingHouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);

        modelBuilder.Entity<BookReview>()
            .HasOne(br => br.Reviewer)
            .WithMany(r => r.BookReviews)
            .HasForeignKey(br => br.ReviewerID);

        modelBuilder.Entity<BookReview>()
            .HasOne(br => br.Book)
            .WithOne(b => b.BookReview)
            .HasForeignKey<BookReview>(br => br.BookID);

        modelBuilder.Entity<Author>()
            .HasOne(a => a.Person)
            .WithOne(p => p.Author)
            .HasForeignKey<Author>(a => a.PersonID);

        modelBuilder.Entity<Reviewer>()
            .HasOne(r => r.Person)
            .WithOne(p => p.Reviewer)
            .HasForeignKey<Reviewer>(r => r.PersonID);

        modelBuilder.Entity<BookEdition>()
            .HasOne(be => be.Book)
            .WithMany(b => b.BookEditions)
            .HasForeignKey(be => be.BookID);

        modelBuilder.Entity<BookEdition>()
            .HasOne(be => be.Publisher)
            .WithMany(ph => ph.BookEditions)
            .HasForeignKey(be => be.PublisherID);

        base.OnModelCreating(modelBuilder);
    }
}
