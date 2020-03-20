using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace VCSAutomationFinalProject._Pages
{
    class ItemInfoPage : BasePage
    {
        private IWebElement AddToWishListElement => driver.FindElement(By.Id("linkToNoticeList"));
        private IWebElement GoBackToTacticalBootsPageElement => driver.FindElement(By.CssSelector("[title='Taktiniai batai']"));
        
        public ItemInfoPage(IWebDriver driver) : base(driver)
        {

        }

        public ItemInfoPage AddItemToWishList()
        {
            var itemId = driver.FindElement(By.CssSelector("#detailsMain [name='anid']")).GetAttribute("value");
            var currentUserWishList = BaseTestWithLogin.CurrentUser.SelectedWishListItemIdlList;
            if (!currentUserWishList.Contains(itemId))
            {
                currentUserWishList.Add(itemId);
            }
            AddToWishListElement.Click();
            return this;
        }

        public TacticalBootsPage ReturnToTacticalBootsPage()
        {
            GoBackToTacticalBootsPageElement.Click();
            return new TacticalBootsPage(driver);
        }
    }
}
