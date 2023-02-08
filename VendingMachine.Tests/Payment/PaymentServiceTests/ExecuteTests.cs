using Moq;
using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.Models;
using RemoteLearning.VendingMachine.Payment;
using RemoteLearning.VendingMachine.PresentationLayer;
using Xunit;

namespace VendingMachine.Tests.Payment.PaymentServiceTests
{
    public class ExecuteTests
    {
        private readonly Mock<IBuyView> buyView;
        private readonly List<Mock<IPaymentAlgorithm>> paymentAlgorithms;
        private readonly List<IPaymentAlgorithm> nullPaymentAlgorithms;
        private readonly PaymentService paymentService;
        private readonly PaymentService nullPaymentService;

        public ExecuteTests()
        {
            buyView = new Mock<IBuyView>();
            paymentAlgorithms = new List<Mock<IPaymentAlgorithm>>()
            {
                new Mock<IPaymentAlgorithm>(),
                new Mock<IPaymentAlgorithm>()
            };

            List<IPaymentAlgorithm> paymentAlgorithmsObject = paymentAlgorithms.ConvertAll(x => x.Object);
            paymentService = new PaymentService(buyView.Object, paymentAlgorithmsObject);

            nullPaymentAlgorithms = new List<IPaymentAlgorithm>();
            nullPaymentService = new PaymentService(buyView.Object, nullPaymentAlgorithms);
        }

        [Fact]
        public void HavingAPaymentService_WhenExecuted_TheUserIsAskedForPaymentMethod()
        {
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns(2);
            paymentAlgorithms.ForEach(x => x.Setup(x => x.Name).Returns("card"));

            paymentService.Execute(It.IsAny<float>());

            buyView.Verify(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()), Times.Once);
        }

        [Fact]
        public void HavingAPaymentService_WhenExecutedOnANullPaymentMethod_ThanThrowsException()
        {
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns<int?>(null);

            Assert.Throws<CancelException>(() =>
            {
                paymentService.Execute(It.IsAny<float>());
            });
        }

        [Fact]
        public void HavingAPaymentService_WhenExecutedOnANullPaymentAlgorithm_ThanThrowsException()
        {
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns<int?>(null);

            Assert.Throws<CancelException>(() =>
            {
                nullPaymentService.Execute(It.IsAny<float>());
            });
        }

        [Fact]
        public void HavingAPaymentService_WhenExecuted_TheUserIsAskedForPaymentMethodAndReturnsTheAlgorithm()
        {
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns(2);
            paymentAlgorithms.ForEach(x => x.Setup(x => x.Name).Returns("card"));

            paymentService.Execute(It.IsAny<float>());

            buyView.Verify(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()), Times.Once);
        }

        [Fact]
        public void HavingAPaymentAlgorithmInstance_WhenExecuted_ThanTheAlgorithmChoosedIsRunned()
        {
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
                .Returns(1);
            paymentAlgorithms[0].Setup(x => x.Name).Returns("cash");
            paymentAlgorithms[1].Setup(x => x.Name).Returns("card");

            paymentService.Execute(It.IsAny<float>());

            paymentAlgorithms[0].Verify(x => x.Run(It.IsAny<float>()), Times.Once());
            paymentAlgorithms[1].Verify(x => x.Run(It.IsAny<float>()), Times.Never());
        }
    }
}
