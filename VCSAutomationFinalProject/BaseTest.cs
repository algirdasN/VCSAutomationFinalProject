using System;
using NUnit.Framework;
using OpenQA.Selenium;
using VCSAutomationFinalProject.Pages;

namespace VCSAutomationFinalProject
{
    abstract class BaseTest
    {
        protected IWebDriver driver;

        protected ChangePasswordPage changePasswordPage;
        protected ItemInfoPage itemInfoPage;
        protected LandingPage landingPage;
        protected TacticalBootsPage tacticalBootsPage;
        protected WishListPage wishListPage;

        [SetUp]
        public void BaseSetup()
        {
            driver = Driver.InitiateDriver(Driver.Browser.Chrome);
            InitiatePages();

            landingPage
                .wait.Implicit(10);

            driver.Url = "https://www.aic.lt";
            landingPage
                .AcceptCookies();
        }

        [TearDown]
        public void BaseTeardown()
        {
            driver.Quit();
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