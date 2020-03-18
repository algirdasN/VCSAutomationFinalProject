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
        private IWebElement LoginModalButton => driver.FindElement(By.CssSelector(".login-btn"));
        private IWebElement UsernameElement => driver.FindElement(By.Id("loginUser"));
        private IWebElement PasswordElement => driver.FindElement(By.Id("loginPwd"));
        private IWebElement LoginButton => driver.FindElement(By.Id("loginButton"));
        private IWebElement LogoutButton => driver.FindElement(By.Id("registerLink"));
        private IWebElement UserInfoElement => driver.FindElement(By.XPath("//*[@class='icon-user']/..")); 
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public LoginPage ClickLoginModalButton()
        {
            LoginModalButton.Click();
            return this;
        }

        public LoginPage EnterUsername(string input)
        {
            UsernameElement.SendKeys(input);
            return this;
        }

        public LoginPage EnterPassword(string input)
        {
            PasswordElement.SendKeys(input);
            return this;
        }

        public LoginPage ClickLoginButton()
        {
            LoginButton.Click();
            return this;
        }

        public void AssertSuccessfulLogin(string name)
        {
            Assert.True(UserInfoElement.Text.Contains(name));
        }

        public LoginPage ClickLogoutButton()
        {
            LogoutButton.Click();
            return this;
        }
        
        public void AssertSuccesfulLogout()
        {
            Assert.NotNull(LoginModalButton);
        }
    }
}
