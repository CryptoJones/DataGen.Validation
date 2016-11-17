using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.Core;

namespace Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                Name = "Karol",
                Age = 17,
                Email = "someemail.com",
                Validator = new Validator<User>(new List<ValidationRule<User>>
                {
                    new ValidationRule<User>(u => !string.IsNullOrWhiteSpace(u.Name), "Musi sie jakoś nazywać."),
                    new ValidationRule<User>(u => u.Age >= 18, "Musi mieć 18 lat albo więcej."),
                    new ValidationRule<User>(u => !string.IsNullOrWhiteSpace(u.Email), "Email jest wymagany."),
                    new ValidationRule<User>(u => u.Email?.IndexOf('@') > 0, "Email mus byc poprawny."),
                }),
            };

            var validationResult = (user as IValidatable<User>)?.Validate();

            Console.WriteLine(validationResult?.ToString());

            Console.ReadKey();
        }
    }

    public class User : IValidatable<User>
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
