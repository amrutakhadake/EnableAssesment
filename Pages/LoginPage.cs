using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightSauceDemoFramework.Framework.Base;

namespace PlaywrightSauceDemoFramework.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IPage page) : base(page)
        { }
        private ILocator username => page.Locator("#user-name");
        private ILocator password => page.Locator("#password");
        private ILocator loginBtn => page.Locator("#login-button");

        public async Task Login(string user, string pass)
        {
            await username.FillAsync(user);
            await password.FillAsync(pass);
            await loginBtn.ClickAsync();
        }
            }
}

