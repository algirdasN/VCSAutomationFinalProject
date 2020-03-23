using NUnit.Framework;
using VCSAutomationFinalProject.Databases;

namespace VCSAutomationFinalProject.Tests
{
    class TacticalBoots : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            tacticalBootsPage
                .GoToTacticalBootsPage();
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
                .FilterByBrand(TacticalBootsBrand.Tactical511)
                .FilterByBrand(TacticalBootsBrand.HiTecMagnum)
                .AssertFilters();

            tacticalBootsPage
                .FilterByBrand(TacticalBootsBrand.Tactical511)
                .AssertFilters();

            tacticalBootsPage
                .FilterByBrand(TacticalBootsBrand.Garmont)
                .FilterByBrand(TacticalBootsBrand.Zamberlan)
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
