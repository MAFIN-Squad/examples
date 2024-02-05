using Mafin.Web.UI.Selenium.Configuration;
using Mafin.Web.UI.Selenium.Driver.Strategy;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Mafin.Web.UI.Selenium.Example;

public abstract class AbstractTest
{
    protected IWebDriver Driver { get; private set; } = null!;

    protected Pages.PagesSpace Ya { get; private set; } = null!;

    [SetUp]
    public void SetUpUi()
    {
        var webConfiguration = WebConfigurationProvider.GetWebConfiguration();
        var strategy = DriverMapping.GetDriverStrategy(webConfiguration);
        Driver = strategy.GetDriver();

        Ya = Driver.Ya(opts => opts.WithBaseUrl("https://www.epam.com")).Pages;

        Ya.HomePage.Open().AcceptCookies();
    }

    [TearDown]
    public void TearDownUi()
    {
        Driver.Quit();
    }
}
