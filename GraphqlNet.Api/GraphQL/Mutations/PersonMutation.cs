using GraphqlNet.Api.Data;
using GraphqlNet.Api.GraphQL.Types;
using GraphqlNet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlNet.Api.GraphQL.Mutations;

public partial class Mutation
{
    public async Task<Person> AddPersonAsync(PersonInput input, [Service] AppDbContext dbContext)
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