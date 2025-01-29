using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject.Pages;
using FluentAssertions;
using System.Runtime.InteropServices;

namespace TestProject.Tests;

[TestFixture]
public class GoogleSearchTests
{
    private const string _baseGoogleSearch = "Selenium C# tutorial";
    private const string _baseSearchResult = "Selenium";

    private IWebDriver _driver;
    private GoogleHomePage _homePage;
    private GoogleSearchResultsPage _resultsPage;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();

        _homePage = new GoogleHomePage(_driver);
        _resultsPage = new GoogleSearchResultsPage(_driver);
    }

    [Test]
    public void GoogleSearch_ShouldDisplayResults()
    {
        // Arrange
        _homePage.Open();
        _homePage.IsSearchBoxPresent().Should().BeTrue();

        //Act
        _homePage.Search(_baseGoogleSearch);

        // Assert
        _resultsPage.AreResultsDisplayed().Should().BeTrue();
        _resultsPage.FirstResultContains(_baseSearchResult).Should().BeTrue();
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}
