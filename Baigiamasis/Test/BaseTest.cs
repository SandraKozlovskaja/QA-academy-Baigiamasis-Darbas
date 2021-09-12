using autotests.Drivers;
using autotests.Page;
using autotests.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace autotests.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        public static BaigiamasisPage baigiamasisPage;
 

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDriver.GetChrome();
            baigiamasisPage = new BaigiamasisPage(driver);
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
