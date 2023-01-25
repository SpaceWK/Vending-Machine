﻿using Moq;
using RemoteLearning.VendingMachine.Authentication;
using RemoteLearning.VendingMachine.UseCases;
using Xunit;

namespace VendingMachine.Tests.UseCases.LogoutUseCaseTests
{
    public class ExecuteTests
    {
        private readonly Mock<IAuthenticationService> authenticationService;

        private readonly LogoutUseCase logoutUseCase;

        public ExecuteTests()
        {
            authenticationService = new Mock<IAuthenticationService>();

            logoutUseCase = new LogoutUseCase(authenticationService.Object);
        }

        [Fact]
        public void HavingALogoutUseCaseInstance_WhenExecuted_TheUserIsLoggedOut()
        {
            logoutUseCase.Execute();

            authenticationService.Verify(x => x.Logout());
        }
    }
}
