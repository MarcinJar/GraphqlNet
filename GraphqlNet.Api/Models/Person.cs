using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlNet.Api.Models;

public class Person
{
    public Guid ID { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string Bio { get; set; } = "";

    public Author? Author { get; set; }
    public Reviewer? Reviewer { get; set; }
}