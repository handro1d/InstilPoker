using Instil.Poker.Core.Interfaces;
using Instil.Poker.Core.Validation;
using Moq;

namespace Instil.Poker.Core.Tests.Fakes
{
    internal sealed class FakeFileValidator : Mock<IFileValidator>
    {
        /// <summary>
        /// Configure result of IsValid method.
        /// </summary>
        /// <param name="isFileValid">Boolean value indicating if file is considered valid.</param>
        public FakeFileValidator WithValidFile(bool isFileValid = true)
        {
            var result = isFileValid
                ? ValidationResult.Success()
                : ValidationResult.Failed("Test Failure");

            Setup(f => f.Validate(It.IsAny<string>(), It.IsAny<string[]>()))
                .Returns(result);

            return this;
        }
    }
}