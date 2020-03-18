using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using VCSAutomationFinalProject._Pages;

namespace VCSAutomationFinalProject
{
    class _BaseLogin : _BaseTest
    {
        private LoginPage loginPage;

        [SetUp]
        public void BaseLogin()
        {
            driver.Url = "https://www.aic.lt";
            AcceptCookies();
            loginPage = new LoginPage(driver);
            loginPage
                .ClickLoginModalButton()
                .EnterUsername(User.Default)
                .EnterPassword(User.Default)
                .ClickLoginButton()
                .AssertSuccessfulLogin(User.Default);
        }

        [TearDown]
        public void BaseLogout()
        {
            loginPage
                .ClickLogoutButton()
                .AssertSuccessfulLogout();
        }
    }
}
