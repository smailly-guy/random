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

        var FileName = "users.txt";
      

        using (StreamWriter sw = new StreamWriter(FileName, false)) 
        {
            foreach (var user in users)
            {

                if (user.email.EndsWith("ukr.net"))
                {
                    Console.WriteLine(user.GetFullInfo());
                    string userinfo = user.GetFullInfo();
                    sw.WriteLine(userinfo); 
                }
            }
        }
        


        Console.WriteLine($"Filtered users count: {users.Count}");
      

        




        


        Console.WriteLine($"\n\nДані користувачів записано у файл {FileName}\n\n");


      
    }

    
}
