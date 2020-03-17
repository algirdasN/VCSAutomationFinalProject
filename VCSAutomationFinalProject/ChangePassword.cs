using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using VCSAutomationFinalProject._Pages;

namespace VCSAutomationFinalProject
{
    class ChangePassword : _BaseTestWithLogin
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
            var standardPassword = "automation";
            var testPassword = "automation3000";
            ChangePasswordMethod(standardPassword, testPassword);
            loginPage
                .ClickLogoutButton()
                .AssertSuccesfulLogout();
            loginPage
                .ClickLoginModalButton()
                .EnterUsername("nazim.dal@aallaa.org")
                .EnterPassword(testPassword)
                .ClickLoginButton()
                .AssertSuccessfulLogin("Nazim Dal");
            ChangePasswordMethod(testPassword,standardPassword);
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
