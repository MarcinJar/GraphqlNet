using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlNet.Api.Models;

public class PublishingHouse
{
    public Guid PublishingHouseID { get; set; } 
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string Country { get; set; }

    public List<BookEdition> BookEditions { get; set; } = [];
}