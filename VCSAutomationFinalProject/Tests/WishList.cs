using NUnit.Framework;

namespace VCSAutomationFinalProject.Tests
{
    class WishList : BaseTestWithLogin
    {
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
