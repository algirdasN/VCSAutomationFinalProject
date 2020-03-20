using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using VCSAutomationFinalProject._Pages;

namespace VCSAutomationFinalProject
{
    class ChangePassword : BaseLogin
    {
        private ChangePasswordPage changePasswordPage;
        private LandingPage landingPage;

        [SetUp]
        public void Setup()
        {
            driver.Url = "https://www.aic.lt/nustatymai/";
            changePasswordPage = new ChangePasswordPage(driver);
            landingPage = new LandingPage(driver);
        }

        [Test]
        public void ChangePasswordTest()
        {
            var testPassword = "automation3000";
            ChangePasswordMethod(User.Default.Password, testPassword);
            landingPage
                .ClickLogoutButton()
                .AssertSuccessfulLogout();
            landingPage
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
