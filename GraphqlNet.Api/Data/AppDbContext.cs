using GraphqlNet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.Data;

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
        ConfigureBook(modelBuilder);
        ConfigurePerson(modelBuilder);
        ConfigureAuthor(modelBuilder);
        ConfigureReviewer(modelBuilder);
        ConfigureBookReview(modelBuilder);
        ConfigureBookEdition(modelBuilder);
        ConfigurePublishingHouse(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private void ConfigureBook(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasKey(b => b.ID); 

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorID);
    }

    private void ConfigureAuthor(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasKey(a => a.ID);

        modelBuilder.Entity<Author>()
            .HasIndex(a => a.PersonID)
            .IsUnique();

        modelBuilder.Entity<Author>()
            .HasOne(a => a.Person)
            .WithOne(p => p.Author)
            .HasForeignKey<Author>(a => a.PersonID);
    }

    private void ConfigureReviewer(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reviewer>()
            .HasKey(r => r.ID); 

        modelBuilder.Entity<Reviewer>()
            .HasIndex(a => a.PersonID)
            .IsUnique();

        modelBuilder.Entity<Author>()
            .HasOne(a => a.Person)
            .WithOne(p => p.Author)
            .HasForeignKey<Author>(a => a.PersonID);

        modelBuilder.Entity<Reviewer>()
            .HasOne(r => r.Person)
            .WithOne(p => p.Reviewer)
            .HasForeignKey<Reviewer>(r => r.PersonID);
    }

    private void ConfigurePerson(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasKey(p => p.ID); 
    }

    private void ConfigureBookReview(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookReview>()
            .HasKey(br => br.ID);

        modelBuilder.Entity<BookReview>()
            .HasOne(br => br.Reviewer)
            .WithMany(r => r.BookReviews)
            .HasForeignKey(br => br.ReviewerID);

        modelBuilder.Entity<BookReview>()
            .HasOne(br => br.Book)
            .WithMany(b => b.BookReviews)
            .HasForeignKey(br => br.BookID);
    }

    private void ConfigureBookEdition(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookEdition>()
            .HasKey(be => be.ID);

        modelBuilder.Entity<BookEdition>()
            .HasOne(be => be.Book)
            .WithMany(b => b.BookEditions)
            .HasForeignKey(be => be.BookID);

        modelBuilder.Entity<BookEdition>()
            .HasOne(be => be.Publisher)
            .WithMany(ph => ph.BookEditions)
            .HasForeignKey(be => be.PublisherID);
    }

    
    private void ConfigurePublishingHouse(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PublishingHouse>()
            .HasKey(ph => ph.ID);
    }
}
