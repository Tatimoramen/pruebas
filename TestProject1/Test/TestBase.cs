using AventStack.ExtentReports;
using Microsoft.Playwright;
using Reportes;

namespace Test
{
    public class TestBase
    {
        protected IPlaywright Playwright;
        protected IBrowser Browser;
        protected IBrowserContext Context;
        protected IPage Page;

        protected static ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void SetupReporting()
        {
            extent = ExtentManager.GetExtent();
        }

        [SetUp]
        public async Task Setup()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();

            test.Info("Navegador inicializado correctamente");
        }

        [TearDown]
        public async Task Cleanup()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test.Pass("El test pasó correctamente ✅");
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Fail($"El test falló ❌ - {errorMessage}");
            }

            await Context.CloseAsync();
            await Browser.CloseAsync();
            Playwright.Dispose();
        }

        [OneTimeTearDown]
        public void TearDownReporting()
        {
            extent.Flush();
        }
    }
}
