namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal interface ICashPaymentTerminal
    {
        string AskForMoney();
        void GiveBackMoney(float price);
    }
}
