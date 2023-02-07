using Moq;
using RemoteLearning.VendingMachine.DataAccess;
using RemoteLearning.VendingMachine.Payment;
using RemoteLearning.VendingMachine.PresentationLayer;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.Payment.CardPaymentTests
{
    public class ConstructorTests
    {
        private readonly Mock<ICardPaymentTerminal> cardPaymentTerminal;

        private readonly CardPayment cardPayment;

        public ConstructorTests()
        {
            cardPaymentTerminal = new Mock<ICardPaymentTerminal>();

            cardPayment = new CardPayment(cardPaymentTerminal.Object);
        }

        [Fact]
        public void WhenInitializingTheService_NameIsSet()
        {
            Assert.Equal("card", cardPayment.Name);
        }

        [Fact]
        public void HavingNullCardPaymentTerminal_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new CardPayment(null);
            }
            );
        }
    }
}