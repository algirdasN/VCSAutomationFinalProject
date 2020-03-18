using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VCSAutomationFinalProject
{
    public class _BaseTest
    {
        public IWebDriver driver;

        [SetUp]
        public void BaseSetup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("incognito", "start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void BaseTeardown()
        {
            driver.Quit();
        }
    }
}