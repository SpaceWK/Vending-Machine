using Moq;
using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.Payment;
using RemoteLearning.VendingMachine.PresentationLayer;
using Xunit;

namespace VendingMachine.Tests.Payment.CardPaymentTests
{
    public class RunTests
    {
        private readonly Mock<ICardPaymentTerminal> cardPaymentTerminal;
        private readonly CardPayment cardPayment;

        public RunTests()
        {
            cardPaymentTerminal = new Mock<ICardPaymentTerminal>();
            cardPayment = new CardPayment(cardPaymentTerminal.Object);
        }

        [Fact]
        public void HavingACardPaymentCaseInstance_WhenRuning_ThenTheUserIsAskedToIntroduceCardNumber()
        {
            cardPaymentTerminal
                .Setup(x => x.AskForCardNumber())
                .Returns("371449635398431");

            cardPayment.Run(It.IsAny<float>());

            cardPaymentTerminal.Verify(x => x.AskForCardNumber(), Times.Once);
        }

        [Fact]
        public void HavingACardPaymentCaseInstance_WhenProcessIsCancelled_ThrowsException()
        {
            cardPaymentTerminal
                .Setup(x => x.AskForCardNumber())
                .Returns<int?>(null);

            Assert.Throws<CancelException>(() =>
            {
                cardPayment.Run(It.IsAny<float>());
            });
        }

        [Fact]
        public void HavingACardPaymentCaseInstance_WhenRuning_VerifyIfTheCardsAreValid()
        {
            cardPaymentTerminal
                .SetupSequence(x => x.AskForCardNumber())
                .Returns("2")
                .Returns("6011111111111117");

            cardPayment.Run(It.IsAny<float>());

            cardPaymentTerminal.Verify(x => x.AskForCardNumber(), Times.Exactly(2));
        }
    }
}
