using Microsoft.Playwright;

namespace TestProject1.Page
{
    public class BasePage(IPage page)
    {
        protected readonly IPage Page = page;

        public async Task EsperarCargaCompletaAsync()
        {
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        public async Task ClickSeguroAsync(ILocator locator)
        {
            await locator.ScrollIntoViewIfNeededAsync();
            await locator.ClickAsync();
        }
    }
}
