namespace GraphqlNet.Api.Models;

public class PublishingHouse
{
    public Guid ID { get; set; } 
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string Country { get; set; }

    public ICollection<BookEdition> BookEditions { get; set; } = [];
}