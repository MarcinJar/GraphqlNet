using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphqlNet.Api.Enums;

namespace GraphqlNet.Api.Models;

public class BookEdition
{
    public Guid ID { get; set; }
    public Guid BookID { get; set; }
    public int EditionNumber { get; set; }
    public FormatEnum Format { get; set; } // Hardcover, Paperback, Digital
    public Guid PublisherID { get; set; }
    public DateTime PublicationDate { get; set; }

    public required Book Book { get; set; }
    public required PublishingHouse Publisher { get; set; }
}