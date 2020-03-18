using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VCSAutomationFinalProject._Pages
{
    class TacticalBootsPage : _BasePage
    {
        private IList<IWebElement> BrandFilterList => driver.FindElements(By.CssSelector(".filter-list:nth-child(6) li"));
        private IList<IWebElement> DisplayedItemList => driver.FindElements(By.CssSelector(".productData"));
        private readonly List<string> selectedBrands = new List<string>();

        public TacticalBootsPage(IWebDriver driver) : base(driver)
        {

        }

        public TacticalBootsPage FilterByBrand(Brand brand)
        {
            var url = driver.Url;
            BrandFilterList[brand.Index].FindElement(By.CssSelector("input")).Click();
            AddRemoveSelectedBrandList(brand);
            WaitForRefresh(url);
            return this;
        }

        public void AssertFilters()
        {
            if (selectedBrands.Count == 0) return;
            foreach (var item in DisplayedItemList)
            {
                var itemBrand = item.FindElement(By.CssSelector("[itemprop='brand']")).GetAttribute("content");
                if (!selectedBrands.Contains(itemBrand))
                {
                    Assert.Fail("Displayed item has unselected brand");
                }
            }
        }

        public void AddRemoveSelectedBrandList(Brand brand)
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
                    BrandFilterList[i].FindElement(By.CssSelector("input")).Click();
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
                    Assert.AreEqual(selected, BrandFilterList[i].FindElement(By.CssSelector("input")).Selected);
                    break;
                }
            }
        }
    }
}
