using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace VCSAutomationFinalProject._Pages
{
    abstract class _BasePage
    {
        protected IWebDriver driver;

        protected _BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForRefresh(string url)
        {
            var counter = 0;
            while (driver.Url == url && counter < 40)
            {
                Thread.Sleep(250);
                counter++;
            }
            if (counter == 40)
            {
                Assert.Fail("Website took more than 10 seconds to refresh");
            }
        }
    }
}
