namespace RemoteLearning.VendingMachine.Payment
{
    internal interface IPaymentService
    {
        void Execute(float price);
    }
}
