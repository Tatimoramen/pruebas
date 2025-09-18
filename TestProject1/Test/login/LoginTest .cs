using Test;
using TestProject1.Page.login;

namespace TestProject1.Test.login
{
    public class LoginTest : TestBase
    {
        [Test]
        public async Task Login_Exitoso()
        {
            var loginPage = new LoginPage(Page);

            test.Info("Navegando a la página de login");
            await loginPage.IrAlLogin("https://www.saucedemo.com/");

            test.Info("Ingresando credenciales");
            await loginPage.HacerLogin("standard_user", "secret_sauce");

            test.Pass("Login realizado correctamente");
        }
    }
}
