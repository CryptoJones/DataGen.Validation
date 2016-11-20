using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Validation.Contracts;
using Validation.Model;
using Validation.Providers;

namespace DataGen.Validation.UnitTests
{
    [TestFixture]
    public class ValidationExtensionsTests
    {
        [Test]
        public void ValidationExtensions_Validate_Object_ReturnValidationResultWithSuccess()
        {
            var objectToValidate = new { };
            var validationRules = Substitute.For<List<IValidationRule<dynamic>>>();
            var validator = Substitute.For<Validator<dynamic>>(validationRules);
            validator.Validate(objectToValidate).Returns(new ValidationResult() { Success = true });

            var actual = objectToValidate.Validate(validator);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Success);
        }

        [Test]
        public void ValidationExtensions_Validate_Object_ReturnValidationResultWithNoSuccessAndEror()
        {
            var objectToValidate = new { };
            var validationRules = Substitute.For<List<IValidationRule<dynamic>>>();
            var validator = Substitute.For<Validator<dynamic>>(validationRules);
            validator.Validate(objectToValidate).Returns((ValidationResult) =>
            {
                var result = new ValidationResult();
                result.Success = false;
                result.AddError("Validation error message");
                return result;
            });

            var actual = objectToValidate.Validate(validator);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.Success);
            Assert.IsNotNull(actual.Errors);
            Assert.That(actual.Errors, Has.Exactly(1).EqualTo("Validation error message"));
        }
    }
}