using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace VCSAutomationFinalProject
{
    class Driver
    {
        public enum Browser
        {
            Chrome,
            Firefox
        }

        public static IWebDriver InitiateDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    return InitiateChrome();
                case Browser.Firefox:
                    return InitiateFirefox();
                default:
                    Assert.Fail("Unsupported Browser");
                    break;
            }
            return null;
        }

        private static IWebDriver InitiateChrome()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("incognito", "start-maximized");
            var driver = new ChromeDriver(options);
            return driver;
        }

        private static IWebDriver InitiateFirefox()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments("-private");
            var driver = new FirefoxDriver(options);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
