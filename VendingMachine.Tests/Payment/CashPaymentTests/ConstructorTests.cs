using Moq;
using VendingMachine.Business.Payment;
using VendingMachine.Business.PresentationLayer;
using Xunit;

namespace VendingMachine.Tests.Payment.CashPaymentTests
{
    public class ConstructorTests
    {
        private readonly Mock<ICashPaymentTerminal> cashPaymentTerminal;

        private readonly CashPayment cashPayment;

        public ConstructorTests()
        {
            cashPaymentTerminal = new Mock<ICashPaymentTerminal>();

            cashPayment = new CashPayment(cashPaymentTerminal.Object);
        }

        [Fact]
        public void WhenInitializingTheService_NameIsSet()
        {
            Assert.Equal("cash", cashPayment.Name);
        }

        [Fact]
        public void HavingNullCardPaymentTerminal_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new CashPayment(null);
            }
            );
        }
    }
}
