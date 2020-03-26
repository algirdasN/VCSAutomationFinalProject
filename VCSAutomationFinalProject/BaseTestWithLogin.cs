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
            InitiatePages();
            
            landingPage
                .wait.Implicit(10);

            driver.Url = "https://www.aic.lt";
            driver.Manage().Cookies.AddCookie(new Cookie("cookieconsent_status", "allow"));

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

            PrintScreen.DoScreenshotOnFailedTests(driver);  // sitas pats pirmas turi buti :)  
            
            driver.Quit();
        }
        // kadangi dvigubai daug kas vaziuota tam atvejui visai gerai tada dar viena klase tureti kuri viska padarytu :) tik reiktu perduoti driverius
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
