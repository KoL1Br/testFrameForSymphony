using OpenQA.Selenium;
using System.Linq;

namespace TestProject.Pages;

public class GoogleSearchResultsPage(IWebDriver driver) : BasePage(driver)
{
    private readonly By _searchResults = By.XPath("//div[@id='search']//h3");

    public bool AreResultsDisplayed() => FindElements(_searchResults).Count != 0;

    public bool FirstResultContains(string keyword)
    {
        var results = FindElements(_searchResults);
        return results.Count > 0 && results.First().Text.Contains(keyword, StringComparison.OrdinalIgnoreCase);
    }
}
