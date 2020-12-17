using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using SpecFlowSeleniumTesting.support;
using SpecFlowSeleniumTesting.pageobjects;
using System.Diagnostics;
using System.Collections.Generic;

namespace SpecFlowSeleniumTesting.steps
{
    [Binding]
    public class LandingPageVerificationSteps
    {
        private IWebDriver _driver;
        private LandingPage _page;

        [Given(@"open my favorite browser")]
        public void GivenOpenMyFavoriteBrowser()
        {
            string browser = Environment.GetEnvironmentVariable("browser") ?? "chrome";
            _driver = DriverManager.getDriver(browser);
        }


        [When(@"I go to UBS landing page")]
        public void WhenIGoToUBSLandingPage()
        {
            _page = LandingPage.NavigateTo(_driver);
        }

        [When(@"I allow all cookies to be stored")]
        public void WhenIAllowAllCookiesToBeStored()
        {
            _page.allowAllCookies();
        }


        [Then(@"page title contains ""(.*)""")]
        public void ThenPageTitleContains(string title)
        {
            Assert.IsTrue(_page.getTitle().Contains(title), "Title doesn't contain '" + title + "'");
        }

        [When(@"I switch page language")]
        public void WhenIChangePageLanguage()
        {
            _page.changePageLanguage();
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string query)
        {
            _page.searchFor(query);
        }

        [Then(@"search results text contains ""(.*)"" query")]
        public void ThenSearchResultsContainsQuery(string query)
        {
            var searchResults = _page.getSearchResults();
            int resultsLength = searchResults.Count;
            int filteredResultsLength = searchResults.FindAll(el => el.Text.ToLower().Contains(query.ToLower())).Count;
            Assert.IsTrue(resultsLength == filteredResultsLength);
        }



        [AfterScenario]
        public void tearDown()
        {
            _page.close();
        }

    }
}
