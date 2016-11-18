using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Validation.Example1
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
                Validator = new Validator<User>(new List<ValidationRule<User>>
                {
                    new ValidationRule<User>(u => !string.IsNullOrWhiteSpace(u.Name), "Has to have a name."),
                    new ValidationRule<User>(u => u.Age >= 18, "Has to be adult."),
                    new ValidationRule<User>(u => !string.IsNullOrWhiteSpace(u.Email), "Email is required."),
                    new ValidationRule<User>(u => u.Email?.IndexOf('@') > 0, "Email has to be in correct format."),
                }),
            };

            var validationResult = (user as IValidatable<User>)?.Validate();
            Console.WriteLine(validationResult?.ToString());

            Console.ReadKey();
        }
    }

    class User : IValidatable<User>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public Validator<User> Validator { get; set; }

        public ValidationResult Validate()
        {
            return this.Validator.Validate(this);
        }
    }
}
