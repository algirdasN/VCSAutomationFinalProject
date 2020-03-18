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
        private ReadOnlyCollection<IWebElement> brandFilterList => driver.FindElements(By.CssSelector(".filter-list:nth-child(6) li"));
        private ReadOnlyCollection<IWebElement> displayedItemList => driver.FindElements(By.CssSelector(".productData"));
        private string[] brandList = { "5.11 Tactical", "Bennon", "EXC", "Garmont", "Hi-Tec Magnum", "Mil-Tec", "Zamberlan", "adidas" };
        private List<string> selectedBrands = new List<string>();

        public TacticalBootsPage(IWebDriver driver) : base(driver)
        {

        }

        public TacticalBootsPage FilterByBrand(int index)
        {
            var url = driver.Url;
            brandFilterList[index].FindElement(By.CssSelector("input")).Click();
            AddRemoveSelectedBrandList(index);
            WaitForRefresh(url);
            return this;
        }

        public void AssertFilters()
        {
            if (selectedBrands.Count == 0) return;
            foreach (var item in displayedItemList)
            {
                var itemBrand = item.FindElement(By.CssSelector("[itemprop='brand']")).GetAttribute("content");
                if (!selectedBrands.Contains(itemBrand))
                {
                    Assert.Fail("Displayed item has unselected brand");
                }
            }
        }

        public void AddRemoveSelectedBrandList(int index)
        {
            if (selectedBrands.Contains(brandList[index]))
            {
                selectedBrands.Remove(brandList[index]);
            }
            else
            {
                selectedBrands.Add(brandList[index]);
            }
        }

        public TacticalBootsPage SelectCheckBoxRange(int min, int max)
        {
            if (min < 1) { min = 1; }
            for (int i = min - 1; i < max; i++)
            {
                while (i < brandFilterList.Count)
                {
                    var url = driver.Url;
                    brandFilterList[i].FindElement(By.CssSelector("input")).Click();
                    WaitForRefresh(url);
                    break;
                }
            }
            return this;
        }

        public void AssertCheckBoxRange(int min, int max, bool selected)
        {
            for (int i = min - 1; i < max; i++)
            {
                Assert.AreEqual(selected, brandFilterList[i].FindElement(By.CssSelector("input")).Selected);
            }
        }
    }
}
