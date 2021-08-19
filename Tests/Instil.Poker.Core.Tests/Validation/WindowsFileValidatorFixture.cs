using Instil.Poker.Core.Tests.Utils;
using Instil.Poker.Core.Validation;
using NUnit.Framework;

namespace Instil.Poker.Core.Tests.Validation
{
    [TestFixture]
    internal sealed class WindowsFileValidatorFixture
    {
        private WindowsFileValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new WindowsFileValidator();
        }

        [Test]
        public void Validate_ShouldReturnFailureForNonExistantFile()
        {
            var result = _validator.Validate("C:\\IDontExist.txt", ".txt");
            Assert.IsFalse(result.Succeeded);
        }

        [Test]
        public void Validate_ShouldReturnFailureForInvalidFormatFilePath()
        {
            var result = _validator.Validate("ImBadlyFormed");
            Assert.IsFalse(result.Succeeded);
        }

        [Test]
        public void Validate_ShouldReturnFailureForInvalidFileType()
        {
            var filePath = AssetUtils.GetPath("TextFile.txt");
            var result = _validator.Validate(filePath, ".csv");
            Assert.IsFalse(result.Succeeded);
        }

        [Test]
        public void Validate_ShouldReturnSuccessForValidFileType()
        {
            var filePath = AssetUtils.GetPath("TextFile.txt");
            var result = _validator.Validate(filePath, ".txt");
            Assert.IsTrue(result.Succeeded);
        }
    }
}