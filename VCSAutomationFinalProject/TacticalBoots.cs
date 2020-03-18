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
                .SelectCheckBoxRange(2, 5)
                .AssertCheckBoxRange(2, 5, true);

            tacticalBootsPage
                .AssertCheckBoxRange(6, 8, false);
        }

        [Test]
        public void FilterByBrandTest()
        {
            tacticalBootsPage
                .FilterByBrand(0)
                .FilterByBrand(4)
                .AssertFilters();

            tacticalBootsPage
                .FilterByBrand(0)
                .AssertFilters();

            tacticalBootsPage
                .FilterByBrand(3)
                .FilterByBrand(7)
                .AssertFilters();
        }
    }
}
