using GraphqlNet.Api.Data;
using GraphqlNet.Api.GraphQL.Types;
using GraphqlNet.Api.Models;

namespace GraphqlNet.Api.GraphQL.Mutations;

public partial class Mutation
{
    public async Task<Person> AddPersonAsync(PersonInput input, [Service] AppDbContext context)
    {
        var (firstName, lastName, email, bio) = input;

        var existPerson = context.Persons
            .FirstOrDefault(a => a.Email == email);
                
        if (existPerson is not null)    
            throw new InvalidOperationException($"Person with this email: {email}, exist!");
        
        var person = new Person() {
            FirstName = firstName,
            Email = email,
            LastName = lastName,
            Bio = bio,
        };

        context.Persons.Add(person);
        await context.SaveChangesAsync();

        return person;
    }
}