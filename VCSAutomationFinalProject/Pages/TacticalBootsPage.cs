using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using VCSAutomationFinalProject.Databases;

namespace VCSAutomationFinalProject.Pages
{
    class TacticalBootsPage : BasePage
    {
        private IList<IWebElement> BrandFilterList => driver.FindElements(By.CssSelector(".filter-list:nth-child(6) input")); 
        private IList<IWebElement> DisplayedItemList => driver.FindElements(By.CssSelector(".productData"));
        private IList<IWebElement> DisplayedItemTitleList => driver.FindElements(By.CssSelector(".titleBox a"));
        private IList<IWebElement> DisplayedItemPriceList => driver.FindElements(By.CssSelector("[itemprop='price']"));
        private IList<IWebElement> DisplayedItemBrandList => driver.FindElements(By.CssSelector("[itemprop='brand']"));
        private IWebElement SortDropDownElement => driver.FindElement(By.CssSelector(".sort-trigger"));
        private IWebElement SortAlphabeticalZAElement => driver.FindElement(By.CssSelector(".dropdown-content li:nth-child(1)"));
        private IWebElement SortAlphabeticalAZElement => driver.FindElement(By.CssSelector(".dropdown-content li:nth-child(2)"));
        private IWebElement SortByPriceDescElement => driver.FindElement(By.CssSelector(".dropdown-content li:nth-child(3)"));
        private IWebElement SortByPriceAscElement => driver.FindElement(By.CssSelector(".dropdown-content li:nth-child(4)"));
        private IList<IWebElement> GoToItemInfoPageButtonList => driver.FindElements(By.CssSelector("a.btn-grey"));

        private readonly List<string> selectedBrands = new List<string>();

        public TacticalBootsPage(IWebDriver driver) : base(driver)
        {

        }

        public TacticalBootsPage ClickSortDropdownElement()
        {
            SortDropDownElement.Click();
            return this;
        }

        public TacticalBootsPage GoToTacticalBootsPage()
        {
            driver.Url = "https://www.aic.lt/Avalyne/Taktiniai-batai";
            return this;
        }

        public TacticalBootsPage SelectSortAlphabeticalZAElement()
        {
            var url = driver.Url;
            SortAlphabeticalZAElement.Click();
            WaitForRefresh(url);
            return this;
        }

        public void AssertSortAlphabeticalZA()
        {
            var expectedList = new List<string>();
            var actualList = new List<string>();
            foreach (var item in DisplayedItemTitleList)
            {
                var title = item.GetAttribute("title");
                expectedList.Add(title);
                actualList.Add(title);  
            }
            expectedList.Sort();
            expectedList.Reverse();
            foreach (var item in expectedList)
            {
                Assert.AreEqual(item, actualList[expectedList.IndexOf(item)]);
            }
        }

        public TacticalBootsPage SelectSortAlphabeticalAZElement()
        {
            var url = driver.Url;
            SortAlphabeticalAZElement.Click();
            WaitForRefresh(url);
            return this;
        }

        public void AssertSortAlphabeticalAZ()
        {
            var expectedList = new List<string>();
            var actualList = new List<string>();
            foreach (var item in DisplayedItemTitleList)
            {
                var title = item.GetAttribute("title");
                expectedList.Add(title);
                actualList.Add(title);
            }
            expectedList.Sort();
            foreach (var item in expectedList)
            {
                Assert.AreEqual(item, actualList[expectedList.IndexOf(item)]);
            }
        }

        public TacticalBootsPage SelectSortByPriceDescElement()
        {
            var url = driver.Url;
            SortByPriceDescElement.Click();
            WaitForRefresh(url);
            return this;
        }

        public void AssertSortByPriceDesc()
        {
            var max = Convert.ToDouble(DisplayedItemPriceList[0].GetAttribute("content"));
            foreach (var item in DisplayedItemPriceList)
            {
                var price = Convert.ToDouble(item.GetAttribute("content"));
                if (price > max)
                {
                    Assert.Fail("Incorrect sort");
                }
                max = price;
            }
        }

        public TacticalBootsPage SelectSortByPriceAscElement()
        {
            var url = driver.Url;
            SortByPriceAscElement.Click();
            WaitForRefresh(url);
            return this;
        }

        public void AssertSortByPriceAsc()
        {
            var min = Convert.ToDouble(DisplayedItemPriceList[0].GetAttribute("content"));
            foreach (var item in DisplayedItemPriceList)
            {
                var price = Convert.ToDouble(item.GetAttribute("content"));
                if (price < min)
                {
                    Assert.Fail("Incorrect sort");
                }
                min = price;
            }
        }

        public TacticalBootsPage FilterByBrand(TacticalBootsBrand brand)
        {
            var url = driver.Url;
            BrandFilterList[brand.Index].Click();
            AddRemoveSelectedBrandList(brand);
            WaitForRefresh(url);
            return this;
        }

        public void AssertFilters()
        {
            if (selectedBrands.Count == 0) return;
            foreach (var item in DisplayedItemBrandList)
            {
                var itemBrand = item.GetAttribute("content");
                if (!selectedBrands.Contains(itemBrand))
                {
                    Assert.Fail("Displayed item has unselected brand");
                }
            }
        }

        public void AddRemoveSelectedBrandList(TacticalBootsBrand brand)
        {
            if (selectedBrands.Contains(brand.BrandName))
            {
                selectedBrands.Remove(brand.BrandName);
            }
            else
            {
                selectedBrands.Add(brand.BrandName);
            }
        }

        public TacticalBootsPage SelectCheckBoxRange(int min, int max)
        {
            if (min < 1) { min = 1; }
            for (int i = min - 1; i < max; i++)
            {
                while (i < BrandFilterList.Count)
                {
                    var url = driver.Url;
                    BrandFilterList[i].Click();
                    WaitForRefresh(url);
                    break;
                }
            }
            return this;
        }

        public void AssertCheckBoxRange(int min, int max, bool selected)
        {
            if (min < 1) { min = 1; }
            for (int i = min - 1; i < max; i++)
            {
                while (i < BrandFilterList.Count)
                {
                    Assert.AreEqual(selected, BrandFilterList[i].Selected);
                    break;
                }
            }
        }

        public ItemInfoPage GoToItemInfoPageByIndex(int index)
        {
            GoToItemInfoPageButtonList[index].Click();
            return new ItemInfoPage(driver);
        }
    }
}
