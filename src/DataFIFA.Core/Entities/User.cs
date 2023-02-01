using DataFIFA.Core.Entities.Shared;

namespace DataFIFA.Core.Entities
{
    public class User : BaseEntity
    {
        public User() { }
        
        public User(string name, string email, string password) 
        {
            Name = name;
            Email = email;
            Password = password;

            Careers = new List<Career>();
        }

        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public List<Career> Careers { get; private set; } = null!;
    }
}