

using static Bogus.DataSets.Name;

namespace перевантаження_операторів
{
    internal class User
    {
        public int Id { get; private set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        
        public string number { get; set; } = String.Empty;
        public string email { get; set; } = String.Empty;
        public Gender Gender { get; set; } 

        public User(int id)
        {
            Id = id;
        }

        public string GetFullInfo()
        {
            return $"{FirstName} {LastName} {email} {number}";
        }

       

    }
}
