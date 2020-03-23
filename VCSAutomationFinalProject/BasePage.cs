using OpenQA.Selenium;
using SeleniumEasyTests;

namespace VCSAutomationFinalProject
{
    abstract class BasePage
    {
        protected IWebDriver driver;
        public Wait wait;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new Wait(driver);
        }

        public void WaitForRefresh(string url)
        {
            wait.Implicit(0);
            wait.Explicit(10)
                .Until(d => driver.Url != url);
            wait.Implicit(10);
        }
    }
}
