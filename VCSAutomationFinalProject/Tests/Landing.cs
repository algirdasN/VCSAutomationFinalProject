using NUnit.Framework;

namespace VCSAutomationFinalProject.Tests
{
    class Landing : BaseTest
    {
        [Test]
        public void FeaturedItemSlideTest()
        {
            landingPage
                .ClickFeaturedButton(3)
                .AssertFeaturedSlide(3);

            landingPage
                .ClickFeaturedButton(6)
                .AssertFeaturedSlide(6);

            landingPage
                .ClickFeaturedButton(0)
                .AssertFeaturedSlide(0);
        }
    }
}
