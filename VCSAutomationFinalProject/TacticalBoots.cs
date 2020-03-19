using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using VCSAutomationFinalProject._Pages;

namespace VCSAutomationFinalProject
{
    class TacticalBoots : _BaseTest
    {
        private TacticalBootsPage tacticalBootsPage;

        [SetUp]
        public void Setup()
        {
            driver.Url = "https://www.aic.lt/Avalyne/Taktiniai-batai";
            tacticalBootsPage = new TacticalBootsPage(driver);
            AcceptCookies();
        }

        [Test]
        public void BrandCheckboxTest()
        {
            tacticalBootsPage
                .SelectCheckBoxRange(1, 5)
                .AssertCheckBoxRange(1, 5, true);

            tacticalBootsPage
                .AssertCheckBoxRange(6, 8, false);

            tacticalBootsPage
                .SelectCheckBoxRange(1, 3)
                .AssertCheckBoxRange(1, 3, false);
        }

        [Test]
        public void FilterByBrandTest()
        {
            tacticalBootsPage
                .FilterByBrand(Brand.Tactical511)
                .FilterByBrand(Brand.HiTecMagnum)
                .AssertFilters();

            tacticalBootsPage
                .FilterByBrand(Brand.Tactical511)
                .AssertFilters();

            tacticalBootsPage
                .FilterByBrand(Brand.Garmont)
                .FilterByBrand(Brand.Zamberlan)
                .AssertFilters();
        }

        [Test]
        public void SortAlphabeticallyTest()
        {
            tacticalBootsPage
                .ClickSortDropdownElement()
                .SelectSortAlphabeticalZAElement()
                .AssertSortAlphabeticalZA();

            tacticalBootsPage
                .ClickSortDropdownElement()
                .SelectSortAlphabeticalAZElement()
                .AssertSortAlphabeticalAZ();
        }

        [Test]
        public void SortByPriceTest()
        {
            tacticalBootsPage
                .ClickSortDropdownElement()
                .SelectSortByPriceDescElement()
                .AssertSortByPriceDesc();

            tacticalBootsPage
                .ClickSortDropdownElement()
                .SelectSortByPriceAscElement()
                .AssertSortByPriceAsc();
        }
    }
}
