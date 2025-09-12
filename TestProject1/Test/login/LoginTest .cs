using TestProject1.Page.login;

namespace TestProject1.Test.login
{
    public class LoginTest : TestBase
    {
        [Test]
        public async Task Login_Exitoso()
        {
            var loginPage = new LoginPage(Page);

            await loginPage.IrAlLogin("https://www.saucedemo.com/");
            await loginPage.HacerLogin("standard_user", "secret_sauce");

        }
    }
}
