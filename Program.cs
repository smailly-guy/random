namespace перевантаження_операторів;
using System;
using System.Runtime.CompilerServices;
using Bogus;
using static Bogus.DataSets.Name;

internal class Program
{   

    
    
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;


        var userId = 1;
        var MyUserfaker = new Faker<User>("uk")
            .CustomInstantiator(f => new User(userId++))
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
            .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(u.Gender))
            .RuleFor(u => u.LastName,  f => f.Name.LastName())
            .RuleFor(u => u.email, (f, u) => f.Internet.Email(u.FirstName,u.LastName))
            .RuleFor(u => u.number, f => f.Phone.PhoneNumber());

            var users = MyUserfaker.Generate(10);
        // Pseudocode:
        // 1. Open a StreamWriter for the target file (e.g., "users.txt").
        // 2. Iterate through the filtered users.
        // 3. For each user, write their full info to the file.
        // 4. Close the StreamWriter after writing all users.


        // Implementation:

        //foreach (var user in users)
        //{
        //    Console.WriteLine(user.GetFullInfo());
        //}
        var FileName = "users.txt";
      

        using (StreamWriter sw = new StreamWriter(FileName, false)) // 'false' to overwrite file
        {
            foreach (var user in users)
            {

                if (user.email.EndsWith("ukr.net"))
                {
                    Console.WriteLine(user.GetFullInfo());
                    string userinfo = user.GetFullInfo();
                    sw.WriteLine(userinfo); // Write each user's info as a line in the file
                }
            }
        }
        


        Console.WriteLine($"Filtered users count: {users.Count}");
      

        




        


        Console.WriteLine($"\n\nДані користувачів записано у файл {FileName}\n\n");


      
    }

    
}
