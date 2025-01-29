using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProject.Pages;

    public class GoogleSearchResultsPage : BasePage
    {
        private readonly By _searchResults = By.XPath("//div[@id='search']//h3");

        public GoogleSearchResultsPage(IWebDriver driver) : base(driver) { }

        public bool AreResultsDisplayed()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            return wait.Until(drv => drv.FindElements(_searchResults).Count > 0);
        }

        public bool FirstResultContains(string keyword)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(drv => drv.FindElements(_searchResults).Count > 0);

            var results = FindElements(_searchResults);

            return results.Count > 0 && results.First().Text.Contains(keyword, StringComparison.OrdinalIgnoreCase);
        }
    }
