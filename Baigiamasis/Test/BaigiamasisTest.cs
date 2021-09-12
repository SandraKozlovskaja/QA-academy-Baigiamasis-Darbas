using NUnit.Framework;

namespace autotests.Test
{
    public class BaigiamasisTest : BaseTest
    {
        //1 Testcase
        [Test]
        public static void TestReturningToHomePageWays()
        {
            baigiamasisPage.NavigateToPage();
            baigiamasisPage.MaistoParuosimasClick();
            baigiamasisPage.DarzoviuPjausktyklesClick();
            baigiamasisPage.PressLogoToGoBackToHomePage();
            baigiamasisPage.MaistoParuosimasClick();
            baigiamasisPage.DarzoviuPjausktyklesClick();
            baigiamasisPage.PressPradinisLinkToGoBackToHomePage();
        }

        //2 Testcase
        [TestCase("puodas", TestName = "Search for PUODAS in search field")]
        [TestCase("keptuvė", TestName = "Search for KEPTUVĖ in search field")]
        public static void TestSearchField(string text)
        {
            baigiamasisPage.NavigateToPage();
            baigiamasisPage.SearchByText(text);
            baigiamasisPage.ClickOnSearchIcon();
            baigiamasisPage.SearchResultByFirstProduct(text);
        }

        //3 Testcase
        [TestCase("Vardenis", "Labai geras ir naudingas daiktas", "Dėkojame už Jūsų įvertinimą. Jis buvo išsiųstas patvirtinimui", TestName = "Leave a review Vardenis")]
        [TestCase("Pavardenis", "Nepaigailėjome, kad įsigijome", "Dėkojame už Jūsų įvertinimą. Jis buvo išsiųstas patvirtinimui", TestName = "Leave a review Pavardenis")]
        public static void TestReviewLeaving(string name, string review, string successMessage)
        {
            baigiamasisPage.NavigateToPage();
            baigiamasisPage.MaistoParuosimasClick();
            baigiamasisPage.DarzoviuPjausktyklesClick();
            baigiamasisPage.GoToProductInsideClick();
            baigiamasisPage.AtsiliepimaiButtonClick();
            baigiamasisPage.LeaveReview(name, review, successMessage);
        }

        //4 Testcase
        [Test]
        public static void TestAddingToCart()
        {
            baigiamasisPage.NavigateToPage();
            baigiamasisPage.MaistoParuosimasClick();
            baigiamasisPage.DarzoviuPjausktyklesClick();
            baigiamasisPage.AddProductToCart();

            baigiamasisPage.CheckIfProductAddedToCart("pjaustykl");
            baigiamasisPage.CheckProductPrice("1", "43");
            baigiamasisPage.IncreaseAmountOfProduct();
            baigiamasisPage.CheckProductPrice("2", "86");
        }

        //5 Testcase
        [Test]
        public static void TestContactUsDataMissingErrors()
        {
            baigiamasisPage.NavigateToPage();
            baigiamasisPage.ContactUsClick();
            baigiamasisPage.SendMessageWithoutDataInputed();
            baigiamasisPage.CheckErrorsAboutMissingData("Vardas turi turėti nuo 3 iki 32 simbolių", "Klaidingai įvestas el. pašto adresas", "Žinutė turi turėti nuo 10 iki 3000 simbolių");
        }

    }
}