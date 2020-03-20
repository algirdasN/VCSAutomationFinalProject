using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace VCSAutomationFinalProject._Pages
{
    class ChangePasswordPage : BasePage
    {
        private IWebElement OldPasswordElement => driver.FindElement(By.Id("passwordOld"));
        private IWebElement NewPasswordElement => driver.FindElement(By.Id("passwordNew"));
        private IWebElement ConfirmPasswordElement => driver.FindElement(By.Id("passwordNewConfirm"));
        private IWebElement SaveNewPasswordButton => driver.FindElement(By.Id("savePass"));
        private IWebElement SuccessMessageElement => driver.FindElement(By.CssSelector(".success-message"));

        public ChangePasswordPage(IWebDriver driver) : base(driver)
        {

        }

        public ChangePasswordPage GoToChangePasswordPage()
        {
            driver.Url = "https://www.aic.lt/nustatymai/";
            return this;
        }

        public ChangePasswordPage EnterOldPassword(string input)
        {
            OldPasswordElement.SendKeys(input);
            return this;
        }

        public ChangePasswordPage EnterNewPassword(string input)
        {
            NewPasswordElement.SendKeys(input);
            return this;
        }

        public ChangePasswordPage ConfirmNewPassword(string input)
        {
            ConfirmPasswordElement.SendKeys(input);
            return this;
        }

        public ChangePasswordPage ClickSaveNewPasswordButton()
        {
            SaveNewPasswordButton.Click();
            return this;
        }

        public void AssertPasswordChangeSuccess()
        {
            Assert.AreEqual("Jūsų slaptažodis buvo pakeistas.", SuccessMessageElement.Text);
        }
    }
}
