using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
