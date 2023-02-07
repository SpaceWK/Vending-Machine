using Moq;
using RemoteLearning.VendingMachine.Models;
using RemoteLearning.VendingMachine.Payment;
using RemoteLearning.VendingMachine.PresentationLayer;
using Xunit;

namespace VendingMachine.Tests.Payment.PaymentServiceTests
{
    public class ConstructorTests
    {
        private readonly Mock<IBuyView> buyView;
        private readonly Mock<List<IPaymentAlgorithm>> paymentAlgorithm;
        private readonly Mock<ICollection<PaymentMethod>> paymentMethods;

        private readonly PaymentService paymentService;

        public ConstructorTests()
        {
            buyView = new Mock<IBuyView>();
            paymentAlgorithm = new Mock<List<IPaymentAlgorithm>>();
            paymentMethods = new Mock<ICollection<PaymentMethod>>();

            paymentService = new PaymentService(buyView.Object, paymentAlgorithm.Object);
        }

        [Fact]
        public void HavingNullBuyView_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new PaymentService(null, paymentAlgorithm.Object);
            }
            );
        }

        [Fact]
        public void HavingNullPaymentAlgorithm_WhenCallingConstructor_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new PaymentService(buyView.Object, null);
            }
            );
        }

        [Fact]
        public void HavingCollectionOfPaymentMethods_WhenCallingConstructor_InitializePaymentMethods()
        {
            PaymentMethod paymentMethod = new PaymentMethod() {
                Id = 1,
                Name = "cash"
            };

            Assert.Equal(1, paymentMethod.Id);
            Assert.Equal("cash", paymentMethod.Name);
        }
    }
}
