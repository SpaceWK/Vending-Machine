namespace RemoteLearning.VendingMachine.Authentication
{
    internal interface IAuthenticationService
    {
        public bool IsUserAuthenticated { get; }
        public void Login(string password);
        public void Logout();
    }
}
