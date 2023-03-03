namespace VendingMachine.Business.PresentationLayer
{
    internal interface ICashPaymentTerminal
    {
        string AskForMoney();
        void GiveBackMoney(float money);
    }
}