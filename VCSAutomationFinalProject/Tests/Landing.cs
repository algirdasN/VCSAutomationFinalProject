using NUnit.Framework;

namespace VCSAutomationFinalProject.Tests
{
    class Landing : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            driver.Url = "https://www.aic.lt";
            AcceptCookies();
        }

        [Test]
        public void FeaturedItemSlideTest()
        {
            landingPage
                .ClickFeaturedButton(3)
                .AssertFeaturedSlide(3);

            landingPage
                .ClickFeaturedButton(7)
                .AssertFeaturedSlide(7);

            landingPage
                .ClickFeaturedButton(0)
                .AssertFeaturedSlide(0);
        }
    }
}
