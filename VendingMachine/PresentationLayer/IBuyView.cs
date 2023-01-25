namespace RemoteLearning.VendingMachine.PresentationLayer
{
    internal interface IBuyView
    {
        public int RequestProduct();
        public void DispenseProduct(string productName);
    }
}
