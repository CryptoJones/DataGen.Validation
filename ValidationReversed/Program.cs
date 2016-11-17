using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.Core;

namespace ValidationReversed
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                Name = "Karol",
                Age = 17,
                Email = "some@email.com",
            };

            var validationRules = new List<ValidationRule<User>>()
            {
                new ValidationRule<User>(u => !string.IsNullOrWhiteSpace(u.Name), "Musi sie jakoś nazywać."),
                new ValidationRule<User>(u => u.Age >= 18, "Musi mieć 18 lat albo więcej."),
                new ValidationRule<User>(u => !string.IsNullOrWhiteSpace(u.Email), "Email jest wymagany."),
                new ValidationRule<User>(u => u.Email?.IndexOf('@') > 0, "Email mus byc poprawny."),
            };

            Validator<User> userValidator = new Validator<User>( validationRules);

            var validationResult = userValidator.Validate(user);

            Console.WriteLine(validationResult.ToString());

            Console.ReadKey();
        }
    }

    public class User 
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }
    }

    
}
