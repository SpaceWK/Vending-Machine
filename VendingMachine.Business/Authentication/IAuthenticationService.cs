﻿namespace VendingMachine.Business.Authentication
{
    internal interface IAuthenticationService
    {
        bool IsUserAuthenticated { get; }
        void Login(string password);
        void Logout();
    }
}
