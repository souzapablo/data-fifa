using DataFIFA.Core.Entities.Shared;

namespace DataFIFA.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string password) 
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}