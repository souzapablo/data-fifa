using System.Collections.Generic;

namespace DataFIFA.UnitTests.Fakers;

public sealed class FakeUser : Faker<User>
{
    public FakeUser() 
    {
        RuleFor(u => u.Id, u => Guid.NewGuid())
            .RuleFor(u => u.Email, u => u.Person.Email)
            .RuleFor(u => u.Name, u => u.Name.FullName())
            .RuleFor(u => u.Careers, u => new List<Career>()
            {
                new (Guid.NewGuid(), "Fake Manager")
            });
    }
}