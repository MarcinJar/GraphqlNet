using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlNet.Api.GraphQL.Types;

public class PersonInput
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Bio { get; set; } = string.Empty;

    public void Deconstruct (out string firstName, out string lastName, out string email, out string bio)
    {
        firstName = FirstName;
        lastName = LastName;
        email = Email;
        bio = Bio ?? string.Empty;
    }
}