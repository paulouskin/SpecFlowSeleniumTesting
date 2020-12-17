using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SpecFlowSeleniumTesting.steps
{
    internal class DriverManager
    {
        public static IWebDriver getDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome": return new ChromeDriver();
                case "firefox": return new FirefoxDriver();
                default: return new ChromeDriver();
            }     
        }
    }
}