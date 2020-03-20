using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace VCSAutomationFinalProject._Pages
{
    class LandingPage : BasePage
    {
        private IWebElement LoginModalButton => driver.FindElement(By.CssSelector(".login-btn"));
        private IWebElement UsernameElement => driver.FindElement(By.Id("loginUser"));
        private IWebElement PasswordElement => driver.FindElement(By.Id("loginPwd"));
        private IWebElement LoginButton => driver.FindElement(By.Id("loginButton"));
        private IWebElement LogoutButton => driver.FindElement(By.Id("registerLink"));
        private IWebElement UserInfoElement => driver.FindElement(By.XPath("//*[@class='icon-user']/.."));
        private IList<IWebElement> FeaturedSlideList => driver.FindElements(By.CssSelector("#featured a:not(.slick-cloned)"));
        private IList<IWebElement> FeaturedButtonList => driver.FindElements(By.CssSelector(".slick-dots li"));

        public LandingPage(IWebDriver driver) : base(driver)
        {

        }

        public LandingPage ClickLoginModalButton()
        {
            LoginModalButton.Click();
            return this;
        }

        public LandingPage EnterUsername(User user)
        {
            UsernameElement.SendKeys(user.Email);
            return this;
        }

        public LandingPage EnterPassword(User user)
        {
            PasswordElement.SendKeys(user.Password);
            return this;
        }

        public LandingPage EnterPasswordString(string password)
        {
            PasswordElement.SendKeys(password);
            return this;
        }

        public LandingPage ClickLoginButton()
        {
            LoginButton.Click();
            return this;
        }

        public void AssertSuccessfulLogin(User user)
        {
            Assert.True(UserInfoElement.Text.Contains(user.Name));
            BaseTestWithLogin.CurrentUser = user;
        }

        public LandingPage ClickLogoutButton()
        {
            LogoutButton.Click();
            return this;
        }
        
        public void AssertSuccessfulLogout()
        {
            Assert.NotNull(LoginModalButton);
        }

        public LandingPage ClickFeaturedButton(int index)
        {
            FeaturedButtonList[index].Click();
            Thread.Sleep(500);
            return this;
        }

        public void AssertFeaturedSlide(int index)
        {
            Assert.AreEqual("false", FeaturedSlideList[index].GetAttribute("aria-hidden"));
        }
    }
}
