using OpenQA.Selenium;

namespace TestProject.Pages;

public class GoogleHomePage(IWebDriver driver) : BasePage(driver)
{
    private const string _baseGoogleUrl = "https://www.google.com";

    private readonly By _searchBox = By.XPath("//textarea[@name='q']");

    public void Open() => Driver.Navigate().GoToUrl(_baseGoogleUrl);

    public bool IsSearchBoxPresent() => WaitForElementToBeVisible(_searchBox).Displayed;

    public void Search(string query)
    {
        var searchBox = WaitForElementToBeClickable(_searchBox);
        searchBox.Clear();
        searchBox.SendKeys(query);
        searchBox.SendKeys(Keys.Enter);
    }
}
