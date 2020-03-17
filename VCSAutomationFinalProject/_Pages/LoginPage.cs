using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;

namespace VCSAutomationFinalProject._Pages
{
    class LoginPage : _BasePage
    {
        private IWebElement loginModalButton => driver.FindElement(By.CssSelector(".login-btn"));
        private IWebElement usernameElement => driver.FindElement(By.Id("loginUser"));
        private IWebElement passwordElement => driver.FindElement(By.Id("loginPwd"));
        private IWebElement loginButton => driver.FindElement(By.Id("loginButton"));
        private IWebElement logoutButton => driver.FindElement(By.Id("registerLink"));
        private IWebElement userInfoElement => driver.FindElement(By.XPath("//*[@class='icon-user']/..")); 
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public LoginPage ClickLoginModalButton()
        {
            loginModalButton.Click();
            return this;
        }

        public LoginPage EnterUsername(string input)
        {
            usernameElement.SendKeys(input);
            return this;
        }

        public LoginPage EnterPassword(string input)
        {
            passwordElement.SendKeys(input);
            return this;
        }

        public LoginPage ClickLoginButton()
        {
            loginButton.Click();
            return this;
        }

        public void AssertSuccessfulLogin(string name)
        {
            Assert.True(userInfoElement.Text.Contains(name));
        }

        public LoginPage ClickLogoutButton()
        {
            logoutButton.Click();
            return this;
        }
        
        public void AssertSuccesfulLogout()
        {
            Assert.NotNull(loginModalButton);
        }
    }
}
