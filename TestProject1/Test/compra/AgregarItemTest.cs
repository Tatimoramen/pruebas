using TestProject1.Page.compra;
using TestProject1.Page.login;

namespace TestProject1.Test.compra
{
    public class AgregarItemTest : TestBase
    {
        [Test]
        public async Task Compra_Exitosa()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.IrAlLogin("https://www.saucedemo.com/");
            await loginPage.HacerLogin("standard_user", "secret_sauce");

            var productsPage = new ProductsPage(Page);
            await productsPage.AgregarProductosAlCarritoAsync();
            await productsPage.IrAlCarritoAsync();

            var checkoutPage = new AgregarItemPage(Page);
            await checkoutPage.IniciarCheckoutAsync();
            await checkoutPage.RellenarInformacionAsync("Tatiana", "Morales", "12345");
            await checkoutPage.ContinuarCheckoutAsync();
            await checkoutPage.FinalizarCheckoutAsync();

            Assert.That(await checkoutPage.ValidarConfirmacionAsync(), Is.True, "La confirmación de la orden no se mostró.");
        }
    }
}