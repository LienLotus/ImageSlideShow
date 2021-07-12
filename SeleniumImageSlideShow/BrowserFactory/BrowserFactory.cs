using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;


namespace SeleniumImageSlideShow.BrowserFactory
{
    class BrowserFactory
    {
        public static IWebDriver driver;

        public static IWebDriver InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;

                case "ie":
                    driver = new InternetExplorerDriver();
                    break;

                case "chrome":
                    driver = new ChromeDriver();
                    break;
                default:
                    throw new System.ComponentModel.InvalidEnumArgumentException();
            }
            return driver;
        }
    }
}
