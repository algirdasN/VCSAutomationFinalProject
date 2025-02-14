﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace VCSAutomationFinalProject.Pages
{
    class WishListPage : BasePage
    {
        private IWebElement RemoveItemFromWishListButton => driver.FindElement(By.CssSelector(".removeButton"));
        private IList<IWebElement> DisplayedWishListItemList => driver.FindElements(By.CssSelector(".productData"));

        public WishListPage(IWebDriver driver) : base(driver)
        {

        }

        public WishListPage GoToWishListPage()
        {
            driver.Url = "https://www.aic.lt/atmintine/";
            return this;
        }

        public WishListPage ClearWishList()
        {
            var wishListCount = DisplayedWishListItemList.Count;
            for (int i = 0; i < wishListCount; i++)
            {
                RemoveItemFromWishListButton.Click();
            }
            return this;
        }

        public void AssertWishList()
        {
            var currentUserWishList = BaseTestWithLogin.CurrentUser.SelectedWishListItemIdlList;
            Assert.AreEqual(currentUserWishList.Count, DisplayedWishListItemList.Count);
            foreach (var item in DisplayedWishListItemList)
            {
                var itemId = item.FindElement(By.CssSelector("[name='anid']")).GetAttribute("value");
                if (!currentUserWishList.Contains(itemId))
                {
                    Assert.Fail("Displayed item was not selected");
                }
            }
        }

        public void AssertEmptyWishList()
        {
            try
            {
                wait.Implicit(0);
                Assert.AreEqual(0, DisplayedWishListItemList.Count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                wait.Implicit(10);
            }
        }
    }
}
