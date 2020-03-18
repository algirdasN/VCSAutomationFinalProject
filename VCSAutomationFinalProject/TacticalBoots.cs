using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
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
        }

        [Test]
        public void BrandCheckboxTest()
        {
            tacticalBootsPage
                .SelectCheckBoxRange(1, 4)
                .AssertCheckBoxRange(1, 4, true);

            tacticalBootsPage
                .AssertCheckBoxRange(5, 8, false);
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
                .AssertFilters();
        }
    }
}
