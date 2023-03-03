namespace VendingMachine.Business.Payment
{
    internal interface IPaymentService
    {
        void Execute(float price);
    }
}
