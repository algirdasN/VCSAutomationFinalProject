using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace VCSAutomationFinalProject
{
    abstract class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void BaseSetup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("incognito", "start-maximized");
            driver = new ChromeDriver(options);

            //FirefoxOptions options = new FirefoxOptions();
            //options.AddArguments("-private");
            //driver = new FirefoxDriver(options);
            //driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void BaseTeardown()
        {
            driver.Quit();
        }

        public void AcceptCookies()
        {
            driver.FindElement(By.CssSelector(".cc-allow")).Click();
        }

    }
}