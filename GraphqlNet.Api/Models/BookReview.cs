using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlNet.Api.Models;

public class BookReview
{
    // ID - GUID
    public Guid ID { get; set; }
    public Guid ReviewerID { get; set; }
    public Guid BookID { get; set; } 
    public int Rating { get; set; }
    public required string ReviewText { get; set; }
    public DateTime ReviewDate { get; set; }

    public required Book Book { get; set; }
    public required Reviewer Reviewer { get; set; }
}