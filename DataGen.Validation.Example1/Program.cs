using System;
using System.Collections.Generic;
using Validation.Contracts;
using Validation.Model;
using Validation.Providers;

namespace Validation.Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            IValidator<User> userValidator = new Validator<User>(new List<IValidationRule<User>>
            {
                new ValidationRule<User>(u => !string.IsNullOrWhiteSpace(u.Name), "Has to have a name."),
                new ValidationRule<User>(u => u.Age >= 18, "Has to be adult."),
                new ValidationRule<User>(u => !string.IsNullOrWhiteSpace(u.Email), "Email is required."),
                new ValidationRule<User>(u => u.Email?.IndexOf('@') > 0, "Email has to be in correct format."),
            });

            User user = new User()
            {
                Name = "John",
                Age = 17,
                Email = "johnemail.com",
                Validator = userValidator,
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

        public IValidator<User> Validator { protected get;  set; }

        public IValidationResult Validate()
        {
            return this.Validator.Validate(this);
        }
    }
}
