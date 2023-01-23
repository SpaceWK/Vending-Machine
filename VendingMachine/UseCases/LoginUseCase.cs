﻿using System;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.PresentationLayer;

namespace RemoteLearning.VendingMachine.UseCases
{
    internal class LoginUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly LoginView loginView;

        public string Name => "login";

        public string Description => "Get access to administration section.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public LoginUseCase(IAuthenticationService authenticationService, LoginView loginView)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
        }

        public void Execute()
        {
            string password = loginView.AskForPassword();
            authenticationService.Login(password);
        }
    }
}