namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal interface IBuyView
    {
        public string RequestProduct();
        public void DispenseProduct(string productName);
    }
}
