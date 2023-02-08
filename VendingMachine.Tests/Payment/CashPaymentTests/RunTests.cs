using Moq;
using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.Payment;
using RemoteLearning.VendingMachine.PresentationLayer;
using Xunit;

namespace VendingMachine.Tests.Payment.CashPaymentTests
{
    public class RunTests
    {
        private readonly Mock<ICashPaymentTerminal> cashPaymentTerminal;
        private readonly CashPayment cashPayment;

        public RunTests()
        {
            cashPaymentTerminal = new Mock<ICashPaymentTerminal>();
            cashPayment = new CashPayment(cashPaymentTerminal.Object);
        }

        [Fact]
        public void HavingACashPaymentCaseInstance_WhenPaymentRun_ThenUserIsAskedToIntroduceCash()
        {
            cashPaymentTerminal
                .Setup(x => x.AskForMoney())
                .Returns("5");

            cashPaymentTerminal
                .Setup(x => x.GiveBackMoney(It.IsAny<float>()));

            cashPayment.Run(5);

            cashPaymentTerminal.Verify(x => x.AskForMoney(), Times.Once);
        }

        [Fact]
        public void HavingACashPaymentCaseInstance_WhenPaymentCanceled_ThrowsException()
        {
            cashPaymentTerminal
                .Setup(x => x.AskForMoney())
                .Returns((string)null);

            Assert.Throws<CancelException>(() =>
            {
                cashPayment.Run(5);
            });
        }

        [Fact]
        public void HavingACashPaymentCaseInstance_WhenMoreCashInsertedThenPrice_GiveBackMoneyIsCalled()
        {
            cashPaymentTerminal
                .Setup(x => x.AskForMoney())
                .Returns("8");

            cashPayment.Run(7);

            cashPaymentTerminal.Verify(x => x.GiveBackMoney(1), Times.Once);
        }

        [Fact]
        public void HavingACashPaymentCaseInstance_WhenPaymentCanceled_GiveBackMoneyAndThrowException()
        {
            cashPaymentTerminal
                .SetupSequence(x => x.AskForMoney())
                .Returns("5")
                .Returns((string)null);

            Assert.Throws<CancelException>(() =>
            {
                cashPayment.Run(15);
                cashPaymentTerminal.Verify(x => x.GiveBackMoney(It.IsAny<float>()), Times.Exactly(2));
            });
        }
    }
}
