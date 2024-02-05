using NUnit.Framework;

namespace Mafin.Web.UI.Selenium.Example;

[Parallelizable(ParallelScope.Fixtures)]
[SetUpFixture]
public class GlobalSetup
{
    [OneTimeSetUp]
    public void OneTimeBaseSetup()
    {
        // something might be here
    }

    [OneTimeTearDown]
    public void AfterAll()
    {
        // something might be here
    }
}
