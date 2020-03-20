using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using VCSAutomationFinalProject._Pages;

namespace VCSAutomationFinalProject
{
    class Landing : BaseTest
    {
        private LandingPage landingPage;

        [SetUp]
        public void Setup()
        {
            driver.Url = "https://www.aic.lt";
            AcceptCookies();
            landingPage = new LandingPage(driver);
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
