using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProject.Pages;

public abstract class BasePage(IWebDriver driver)
{
    protected IWebDriver Driver = driver;

    private readonly WebDriverWait _wait = new(driver, TimeSpan.FromSeconds(5));
    
    protected IWebElement FindElement(By locator) => _wait.Until(drv => drv.FindElement(locator));
    protected IReadOnlyCollection<IWebElement> FindElements(By locator) => Driver.FindElements(locator);

    protected IWebElement WaitForElementToBeVisible(By locator) =>
    _wait.Until(drv =>
    {
        var element = drv.FindElement(locator);
        return element.Displayed ? element : null;
    });

    protected IWebElement WaitForElementToBeClickable(By locator) =>
     _wait.Until(drv =>
    {
        var element = drv.FindElement(locator);
        return element.Displayed && element.Enabled ? element : null;
    });
}
