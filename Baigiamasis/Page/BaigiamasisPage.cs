using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace autotests.Page
{
    public class BaigiamasisPage : BasePage
    {
        private const string AddressUrl = "https://bivip.lt/";

        //1 Testcase
        private IWebElement maistoParuosimasButton => Driver.FindElement(By.CssSelector("#product-categories > ul > li:nth-child(3) > a"));
        private IWebElement darzoviuPjausktyklesLink => Driver.FindElement(By.CssSelector("#category-inner > div:nth-child(2) > div > div > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div > div > a"));
        private IWebElement logoToHomePageButton => Driver.FindElement(By.CssSelector("body > div.page_wrapper > header > div > div:nth-child(1) > div > div > div.left > a > img"));
        private IWebElement pradinisToHomePageLink => Driver.FindElement(By.CssSelector("#products > div:nth-child(1) > div > ul > li:nth-child(1) > a"));


        //2 Testcase
        private IWebElement searchField => Driver.FindElement(By.CssSelector("body > div.page_wrapper > header > div > div:nth-child(1) > div > div > div.right > div > div > input.search-input"));
        private IWebElement searchIcon => Driver.FindElement(By.CssSelector("body > div.page_wrapper > header > div > div:nth-child(1) > div > div > div.right > div > div > input.submit-input"));
        private IWebElement searchResultProduct => Driver.FindElement(By.CssSelector("#mfilter-content-container > div.row.row-products > div:nth-child(1) > div > div.info > h2 > a"));


        // 3 Testcase
        private IWebElement goToProductInside => Driver.FindElement(By.CssSelector("#mfilter-content-container > div.row.row-products > div:nth-child(1) > div > div.info > h2 > a"));
        private IWebElement atsiliepimaiButton => Driver.FindElement(By.CssSelector("#tabs-nav > li:nth-child(3) > span"));

        private IWebElement inputName => Driver.FindElement(By.Id("input-name"));
        private IWebElement inputReview => Driver.FindElement(By.Id("input-review"));
        private IWebElement evaluateProduct => Driver.FindElement(By.CssSelector("#form-review > div:nth-child(5) > fieldset > label:nth-child(2)"));
        private IWebElement continueButton => Driver.FindElement(By.Id("button-review"));
        private IWebElement reviewSuccessMessage => Driver.FindElement(By.CssSelector("#form-review > div.alert.alert-success"));


        // 4 Testcase
        private IWebElement addToCartButton => Driver.FindElement(By.CssSelector("#mfilter-content-container > div.row.row-products > div:nth-child(1) > div > div.info > button"));
        private IWebElement goToCartButton => Driver.FindElement(By.CssSelector("#cart"));
        private IWebElement productIsInCart => Driver.FindElement(By.CssSelector("#cart_view > div > div.qc-checkout-product.panel-body > table > tbody > tr > td.qc-name > a"));
        private IWebElement productPriceInCartIncreased => Driver.FindElement(By.CssSelector("#cart_view > div > div.qc-checkout-product.panel-body > table > tbody > tr > td.qc-total"));
        private IWebElement increaseProductAmountInCartButton => Driver.FindElement(By.CssSelector("#cart_view > div > div.qc-checkout-product.panel-body > table > tbody > tr > td.qc-quantity > div > span:nth-child(3) > button.btn.btn-primary.increase.hidden-xs"));


        //5 Testcase
        private IWebElement susisiektiButton => Driver.FindElement(By.CssSelector("#top-bar > div > div > div > div.left > div > a.btn.btn-sm.btn-wht"));
        private IWebElement siustiButton => Driver.FindElement(By.CssSelector("#contacts > div:nth-child(2) > div:nth-child(1) > form > div > div:nth-child(4) > div > input.btn.btn-lg.btn-red"));
        private IWebElement nameError => Driver.FindElement(By.CssSelector("#contacts > div:nth-child(2) > div:nth-child(1) > form > div > div:nth-child(1) > div > div:nth-child(1) > div > div"));
        private IWebElement emailError => Driver.FindElement(By.CssSelector("#contacts > div:nth-child(2) > div:nth-child(1) > form > div > div:nth-child(2) > div > div:nth-child(2) > div > div"));
        private IWebElement messageError => Driver.FindElement(By.CssSelector("#contacts > div:nth-child(2) > div:nth-child(1) > form > div > div:nth-child(3) > div > div"));



        public BaigiamasisPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }

        public void MaistoParuosimasClick()
        {
            maistoParuosimasButton.Click();
        }

        public void DarzoviuPjausktyklesClick()
        {
            darzoviuPjausktyklesLink.Click();
        }

        public void PressLogoToGoBackToHomePage()
        {
            logoToHomePageButton.Click();
        }

        public void PressPradinisLinkToGoBackToHomePage()
        {
            pradinisToHomePageLink.Click();
        }

        public void SearchByText(string text)
        {
            searchField.Clear();
            searchField.SendKeys(text);
            searchIcon.Click();
        }

        public void ClickOnSearchIcon()
        {
            searchIcon.Click();
        }

        public void SearchResultByFirstProduct(string text)
        {
            Assert.IsTrue(searchResultProduct.Text.Contains(text), "There is no word from search field");
        }

        public void GoToProductInsideClick()
        {
            goToProductInside.Click();
        }

        public void AtsiliepimaiButtonClick()
        {
            atsiliepimaiButton.Click();
        }

        public void LeaveReview(string name, string review, string successMessage)
        {
            inputName.SendKeys(name);
            inputReview.SendKeys(review);
            evaluateProduct.Click();
            continueButton.Click();
            Assert.IsTrue(reviewSuccessMessage.Text.Contains(successMessage), "Message was wrong");
        }

        public void AddProductToCart()
        {
            addToCartButton.Click();
        }

        public void CheckIfProductAddedToCart(string productTitle)
        {
            goToCartButton.Click();
            Assert.IsTrue(productIsInCart.Text.Contains(productTitle), "Product wasn't added to Cart");

        }

        public void IncreaseAmountOfProduct()
        {
            increaseProductAmountInCartButton.Click();
        }

        public void CheckProductPrice(string amount, string productPrice)
        {
            GetWait().Until(ExpectedConditions.TextToBePresentInElementValue(By.CssSelector("#cart_view > div > div.qc-checkout-product.panel-body > table > tbody > tr > td.qc-quantity > div > input"), amount));
            Assert.IsTrue(productPriceInCartIncreased.Text.Contains(productPrice), $"Price isn't correct, {productPriceInCartIncreased.Text}");
        }

        public void ContactUsClick()
        {
            susisiektiButton.Click();
        }

        public void SendMessageWithoutDataInputed()
        {
            siustiButton.Click();
        }

        public void CheckErrorsAboutMissingData(string errorForName, string errorForEmail, string errorForMessage)
        { 
            Assert.IsTrue(nameError.Text.Contains(errorForName), "Message was wrong");
            Assert.IsTrue(emailError.Text.Contains(errorForEmail), "Message was wrong");
            Assert.IsTrue(messageError.Text.Contains(errorForMessage), "Message was wrong");
        }
    }
}
