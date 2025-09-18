using Microsoft.Playwright;

namespace Page.login
{
    internal class LoginPage : BasePage
    {
        private readonly ILocator _usernameInput;
        private readonly ILocator _passwordInput;
        private readonly ILocator _loginButton;

        public LoginPage(IPage page) : base(page)
        {
            _usernameInput = Page.Locator("#user-name");
            _passwordInput = Page.Locator("#password");
            _loginButton = Page.Locator("#login-button");
        }

        public async Task IrAlLogin(string url)
        {
            await Page.GotoAsync(url);
        }

        public async Task HacerLogin(string usuario, string password)
        {
            await _usernameInput.FillAsync(usuario);
            await _passwordInput.FillAsync(password);
            await _loginButton.ClickAsync();
        }
    }
}