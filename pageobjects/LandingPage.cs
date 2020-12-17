using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowSeleniumTesting.support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSeleniumTesting.pageobjects
{
    class LandingPage
    {
        private readonly IWebDriver _driver;

        private readonly int WAIT_TIME = 10;

        private readonly string LANGUAGE_BUTTON_CSS = ".js-language-wrapper";
        private readonly string ACCEPT_ALL_COOKIES_BUTTON_CSS = ".privacysettings__allowAllCookies";
        private readonly string SEARCH_BUTTON_CSS = ".js-header-search-toggle";
        private readonly string SEARCH_BOX_ID = "searchbox";
        private readonly string SEARCH_RESULT_ITEM_CSS = ".search-result-item";

        private LandingPage(IWebDriver driver)
        {
            this._driver = driver;
           
        }

        public static LandingPage NavigateTo(IWebDriver driver)
        {
            string host =
               EnvironmentProvider.getEnvironment(Environment.GetEnvironmentVariable("testEnvironment") ?? "development");
            driver.Navigate().GoToUrl(host);
            return new LandingPage(driver);
        }

        internal void allowAllCookies()
        {
            findElementWithWait(By.CssSelector(ACCEPT_ALL_COOKIES_BUTTON_CSS)).Click();
        }

        public string getTitle()
        {
            return _driver.Title;
        } 

        public void changePageLanguage()
        {
            findElementWithWait(By.CssSelector(LANGUAGE_BUTTON_CSS)).Click();
        }

        public void close()
        {
            _driver.Quit();
        }
        public List<IWebElement> getSearchResults()
        {
            return new List<IWebElement>(findElementsWithWait(By.CssSelector(SEARCH_RESULT_ITEM_CSS)));
        }
        public void searchFor(string query)
        {
            getSearchButton().Click();
            IWebElement searchBox = findElementWithWait(By.Id(SEARCH_BOX_ID));
            searchBox.Clear();
            searchBox.SendKeys(query + Keys.Enter);
        }

        private IWebElement getSearchButton()
        {
            return findElementWithWait(By.CssSelector(SEARCH_BUTTON_CSS));
        }

        private IWebElement findElementWithWait(By locator)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_TIME))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        private ICollection<IWebElement> findElementsWithWait(By locator)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(WAIT_TIME))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }
    }
}
