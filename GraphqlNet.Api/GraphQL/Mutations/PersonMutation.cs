using GraphqlNet.Api.Data;
using GraphqlNet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.GraphQL.Mutations;

public class AddPersonInput
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

public partial class Mutation
{
    public async Task<Person> AddPersonAsync(AddPersonInput input, [Service] AppDbContext dbContext)
    {
        var (firstName, lastName, email, bio) = input;

        var existPerson = await dbContext.Persons
            .FirstOrDefaultAsync(a => a.Email == email);
                
        if (existPerson is not null)    
            throw new InvalidOperationException($"Person with this email: {email}, exist!");
        
        var person = new Person() {
            FirstName = firstName,
            Email = email,
            LastName = lastName,
            Bio = bio,
        };

        dbContext.Persons.Add(person);
        await dbContext.SaveChangesAsync();

        return person;
    }
}