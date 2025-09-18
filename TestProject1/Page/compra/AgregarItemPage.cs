using Microsoft.Playwright;

namespace Page.compra
{
    internal class AgregarItemPage : BasePage
    {
        private readonly ILocator _checkoutButton;
        private readonly ILocator _inputFirstName;
        private readonly ILocator _inputLastName;
        private readonly ILocator _btnContinue;
        private readonly ILocator _btnFinish;
        private readonly ILocator _lblOrderConfirmation;
        private readonly ILocator _inputPostalCode;

        public AgregarItemPage(IPage page) : base(page)
        {
            _checkoutButton = Page.Locator("#checkout");
            _inputFirstName = Page.Locator("#first-name");
            _inputLastName = Page.Locator("#last-name");
            _inputPostalCode = Page.Locator("#postal-code");
            _btnContinue = Page.Locator("#continue");
            _btnFinish = Page.Locator("#finish");
            _lblOrderConfirmation = Page.Locator("text=Thank you for your order!");
        }

        public async Task IniciarCheckoutAsync()
        {
            await _checkoutButton.ClickAsync();
        }

        public async Task RellenarInformacionAsync(string nombre, string apellido, string postalCode)
        {
            await _inputFirstName.FillAsync(nombre);
            await _inputLastName.FillAsync(apellido);
            await _inputPostalCode.FillAsync(postalCode);
        }

        public async Task ContinuarCheckoutAsync()
        {
            await _btnContinue.ClickAsync();
        }

        public async Task FinalizarCheckoutAsync()
        {
            await _btnFinish.ClickAsync();
        }

        public async Task<bool> ValidarConfirmacionAsync()
        {
            return await _lblOrderConfirmation.IsVisibleAsync();
        }
    }
}
