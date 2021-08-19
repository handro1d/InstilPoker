using Instil.Poker.Core.Interfaces;
using Instil.Poker.Core.Validation;
using Instil.Poker.Domain.Interfaces;
using Moq;

namespace Instil.Poker.Core.Tests.Fakes
{
    internal sealed class FakeHandValidator : Mock<IHandValidator>
    {
        public FakeHandValidator WithValidHand(bool isHandValid = true)
        {
            Setup(hv => hv.Validate(It.IsAny<IPokerHand>()))
                .Returns((IPokerHand pokerHand) =>
                {
                    return isHandValid
                        ? ValidationResult.Success() 
                        : ValidationResult.Failed("Test Exception");
                });

            return this;
        }
    }
}
