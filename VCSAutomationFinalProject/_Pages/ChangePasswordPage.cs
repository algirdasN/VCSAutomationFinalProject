using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace VCSAutomationFinalProject._Pages
{
    class ChangePasswordPage : _BasePage
    {
        private IWebElement oldPasswordElement => driver.FindElement(By.Id("passwordOld"));
        private IWebElement newPasswordElement => driver.FindElement(By.Id("passwordNew"));
        private IWebElement confirmPasswordElement => driver.FindElement(By.Id("passwordNewConfirm"));
        private IWebElement saveNewPasswordButton => driver.FindElement(By.Id("savePass"));
        private IWebElement successMessageElement => driver.FindElement(By.CssSelector(".success-message"));

        public ChangePasswordPage(IWebDriver driver) : base(driver)
        {

        }

        public ChangePasswordPage EnterOldPassword(string input)
        {
            oldPasswordElement.SendKeys(input);
            return this;
        }

        public ChangePasswordPage EnterNewPassword(string input)
        {
            newPasswordElement.SendKeys(input);
            return this;
        }

        public ChangePasswordPage ConfirmNewPassword(string input)
        {
            confirmPasswordElement.SendKeys(input);
            return this;
        }

        public ChangePasswordPage ClickSaveNewPasswordButton()
        {
            saveNewPasswordButton.Click();
            return this;
        }

        public void AssertPasswordChangeSuccess()
        {
            Assert.AreEqual("Jūsų slaptažodis buvo pakeistas.", successMessageElement.Text);
        }
    }
}
