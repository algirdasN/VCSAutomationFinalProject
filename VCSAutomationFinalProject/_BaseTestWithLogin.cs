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
    class _BaseTestWithLogin
    {
        public IWebDriver driver;
        private LoginPage loginPage;
        
        [SetUp]
        public void BaseSetup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("incognito", "start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://www.aic.lt";
            loginPage = new LoginPage(driver);
            loginPage
                .ClickLoginModalButton()
                .EnterUsername("nazim.dal@aallaa.org")
                .EnterPassword("automation")
                .ClickLoginButton()
                .AssertSuccessfulLogin("Nazim Dal");
        }

        [TearDown]
        public void BaseTeardown()
        {
            loginPage
                .ClickLogoutButton()
                .AssertSuccesfulLogout();
            driver.Quit();
        }
    }
}
