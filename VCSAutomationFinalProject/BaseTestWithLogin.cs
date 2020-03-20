﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using VCSAutomationFinalProject.Databases;
using VCSAutomationFinalProject.Pages;

namespace VCSAutomationFinalProject
{
    class BaseTestWithLogin
    {
        protected IWebDriver driver;

        protected ChangePasswordPage changePasswordPage;
        protected ItemInfoPage itemInfoPage;
        protected LandingPage landingPage;
        protected TacticalBootsPage tacticalBootsPage;
        protected WishListPage wishListPage;

        public static User CurrentUser;

        [SetUp]
        public void BaseLogin()
        {
            driver = Driver.InitiateDriver(Driver.Browser.Chrome);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            InitiatePages();

            driver.Url = "https://www.aic.lt";
            AcceptCookies();
           
            landingPage
                .ClickLoginModalButton()
                .EnterUsername(User.Default)
                .EnterPassword(User.Default)
                .ClickLoginButton()
                .AssertSuccessfulLogin(User.Default);
        }

        [TearDown]
        public void BaseLogout()
        {
            landingPage
                .ClickLogoutButton()
                .AssertSuccessfulLogout();

            driver.Quit();
        }

        public void AcceptCookies()
        {
            driver.FindElement(By.CssSelector(".cc-allow")).Click();
        }

        public void InitiatePages()
        {
            changePasswordPage = new ChangePasswordPage(driver);
            itemInfoPage = new ItemInfoPage(driver);
            landingPage = new LandingPage(driver);
            tacticalBootsPage = new TacticalBootsPage(driver);
            wishListPage = new WishListPage(driver);
        }
    }
}
