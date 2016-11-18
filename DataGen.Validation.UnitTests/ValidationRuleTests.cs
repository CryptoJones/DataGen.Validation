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
    public class ValidationRuleTests
    {
        [Test]
        public void ValudationRule_Run_InvalidObject_ReturnFalse()
        {
            var objectToValidate = new { PropertyToValidate = 3 };
            var validationRule = new ValidationRule<dynamic>(x => x.PropertyToValidate > 7, "PropertyToValidate has to be grater than seven.");
            //var validationRules = new List<IValidationRule<dynamic>>() { validationRule };
            //var validator = Substitute.For<IValidator<dynamic>>(validationRules);

            var actual = validationRule.Run(objectToValidate);

            Assert.IsFalse(actual);
        }

        [Test]
        public void ValudationRule_Run_ValidObject_ReturnTrue()
        {
            var objectToValidate = new { PropertyToValidate = 9 };
            var validationRule = new ValidationRule<dynamic>(x => x.PropertyToValidate > 7, "PropertyToValidate has to be grater than seven.");

            var actual = validationRule.Run(objectToValidate);

            Assert.IsTrue(actual);
        }
    }
}