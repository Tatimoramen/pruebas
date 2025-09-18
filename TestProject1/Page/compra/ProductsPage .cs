using Microsoft.Playwright;
using Page;

namespace TestProject1.Page.compra
{
    public class ProductsPage : BasePage
    {
        private readonly ILocator _btnAddBackpack;
        private readonly ILocator _btnAddBikeLight;
        private readonly ILocator _btnAddFleeceJacket;
        private readonly ILocator _cartButton;

        public ProductsPage(IPage page) : base(page)
        {
            _btnAddBackpack = Page.Locator("#add-to-cart-sauce-labs-backpack");
            _btnAddBikeLight = Page.Locator("#add-to-cart-sauce-labs-bike-light");
            _btnAddFleeceJacket = Page.Locator("#add-to-cart-sauce-labs-fleece-jacket");
            _cartButton = Page.Locator("#shopping_cart_container");
        }

        public async Task AgregarProductosAlCarritoAsync()
        {
            await _btnAddBackpack.ClickAsync();
            await _btnAddBikeLight.ClickAsync();
            await _btnAddFleeceJacket.ClickAsync();
        }

        public async Task IrAlCarritoAsync()
        {
            await _cartButton.ClickAsync();
        }
    }
}