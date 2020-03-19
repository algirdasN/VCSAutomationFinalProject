using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using VCSAutomationFinalProject._Pages;

namespace VCSAutomationFinalProject
{
    class ChangePassword : _BaseLogin
    {
        private ChangePasswordPage changePasswordPage;
        private LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            driver.Url = "https://www.aic.lt/nustatymai/";
            changePasswordPage = new ChangePasswordPage(driver);
            loginPage = new LoginPage(driver);
        }

        [Test]
        public void ChangePasswordTest()
        {
            var testPassword = "automation3000";
            ChangePasswordMethod(User.Default.Password, testPassword);
            loginPage
                .ClickLogoutButton()
                .AssertSuccessfulLogout();
            loginPage
                .ClickLoginModalButton()
                .EnterUsername(User.Default)
                .EnterPasswordString(testPassword)
                .ClickLoginButton()
                .AssertSuccessfulLogin(User.Default);
            ChangePasswordMethod(testPassword, User.Default.Password);
        }

        public void ChangePasswordMethod(string oldPassword, string newPassword)
        {
            changePasswordPage
                .EnterOldPassword(oldPassword)
                .EnterNewPassword(newPassword)
                .ConfirmNewPassword(newPassword)
                .ClickSaveNewPasswordButton()
                .AssertPasswordChangeSuccess();
        }
    }
}
