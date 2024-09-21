using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlNet.Api.Models;

public class Reviewer
{
    public Guid ID { get; set; }    
    public Guid PersonID { get; set; }

    public required Person Person { get; set; }
    public List<BookReview> BookReviews { get; set; } = [];
}