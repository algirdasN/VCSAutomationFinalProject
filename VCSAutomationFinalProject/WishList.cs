using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using VCSAutomationFinalProject._Pages;

namespace VCSAutomationFinalProject
{
    class WishList : _BaseLogin
    {
        private TacticalBootsPage tacticalBootsPage;
        private WishListPage wishListPage;

        [SetUp]
        public void Setup()
        {
            tacticalBootsPage = new TacticalBootsPage(driver);
            wishListPage = new WishListPage(driver);
        }

        [TearDown]
        public void Teardown()
        {
            wishListPage
               .ClearWishList()
               .AssertEmptyWishList();
        }

        [Test]
        public void AddTacticalBootsToWishListTest()
        {
            tacticalBootsPage
                .GoToTacticalBootsPage()
                .GoToItemInfoPageByIndex(0)
                .AddItemToWishList()
                .ReturnToTacticalBootsPage()
                .GoToItemInfoPageByIndex(0)
                .AddItemToWishList()
                .ReturnToTacticalBootsPage()
                .GoToItemInfoPageByIndex(2)
                .AddItemToWishList();

            wishListPage
                .GoToWishListPage()
                .AssertWishList();

            tacticalBootsPage
                .GoToTacticalBootsPage()
                .GoToItemInfoPageByIndex(1)
                .AddItemToWishList();

            wishListPage
                .GoToWishListPage()
                .AssertWishList();
        }
    }
}
