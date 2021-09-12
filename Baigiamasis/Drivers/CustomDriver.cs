using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;

namespace autotests.Drivers
{
    public class CustomDriver
    {
        public static IWebDriver GetChrome()
        {
            return GetDriver(Browsers.Chrome);
        }

        public static IWebDriver GetFirefox()
        {
            return GetDriver(Browsers.Firefox);
        }
        
        public static IWebDriver GetOpera()
        {
            return GetDriver(Browsers.Opera);
        }

        private static IWebDriver GetDriver(Browsers webDriver)
        {
            IWebDriver driver = null;
            switch(webDriver)
            {
                case Browsers.Chrome:
                    driver = new ChromeDriver();
                    break;
                case Browsers.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case Browsers.Opera:
                    driver = new OperaDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

    }
}
