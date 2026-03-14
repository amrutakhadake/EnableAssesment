using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace PlaywrightSauceDemoFramework.Framework.Hooks
{
    [Binding]
    public class Hooks
    {
        public static IPlaywright Playwright;
        public static IBrowser Browser;
        public static IPage Page;
        public static IAPIRequestContext ApiContext;

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await Browser.NewContextAsync();
            Page = await context.NewPageAsync();
            await Page.GotoAsync("https://www.saucedemo.com");
            // Setup API Context
            ApiContext = await Playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "https://buggy.justtestit.org/overall"
            });
        }
        [AfterScenario]
        public async Task AfterScenario()
        {
            await Browser.CloseAsync();
            await ApiContext.DisposeAsync();
        }
    }
}
