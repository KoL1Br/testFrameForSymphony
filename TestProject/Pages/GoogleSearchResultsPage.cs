using OpenQA.Selenium;
using System.Linq;

namespace TestProject.Pages;
public class GoogleSearchResultsPage : BasePage
{
    private readonly By _searchResults = By.XPath("//div[@id='search']//h3");

    public GoogleSearchResultsPage(IWebDriver driver) : base(driver) { }

    public bool AreResultsDisplayed() => FindElements(_searchResults).Any();

    public bool FirstResultContains(string keyword)
    {
        var results = FindElements(_searchResults);
        return results.Count > 0 && results.First().Text.Contains(keyword, StringComparison.OrdinalIgnoreCase);
    }
}
