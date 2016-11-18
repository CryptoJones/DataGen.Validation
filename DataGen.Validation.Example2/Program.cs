using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Validation.Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                Name = "John",
                Age = 17,
                Email = "johnemail.com",
            };

            var validationRules = new List<ValidationRule<User>>()
            {
                new ValidationRule<User>(u => !string.IsNullOrWhiteSpace(u.Name), "Has to have a name."),
                new ValidationRule<User>(u => u.Age >= 18, "Has to be adult."),
                new ValidationRule<User>(u => !string.IsNullOrWhiteSpace(u.Email), "Email is required."),
                new ValidationRule<User>(u => u.Email?.IndexOf('@') > 0, "Email has to be in correct format."),
            };

            Validator<User> userValidator = new Validator<User>( validationRules);
            var validationResult = userValidator.Validate(user);
            Console.WriteLine(validationResult.ToString());

            Console.ReadKey();
        }
    }

    class User 
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }
    }
}
