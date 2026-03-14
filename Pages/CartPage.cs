using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightSauceDemoFramework.Framework;
using PlaywrightSauceDemoFramework.Framework.Base;
using NUnit.Framework;

namespace PlaywrightSauceDemoFramework.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IPage page) : base(page)
        { }
        public ILocator removeButton => page.GetByRole(AriaRole.Button, new() { Name = "Remove" });

        public ILocator continueShoppingButton => page.GetByRole(AriaRole.Button, new() { Name = "Go back Continue Shopping" });
        public ILocator checkOutButton => page.GetByRole(AriaRole.Button, new() { Name = "Checkout" });

        public async Task VerifyRemoveButton()
        {
            int count = await removeButton.CountAsync();
            if (count == 0)
            {
                Console.WriteLine("No Remove buttons found");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                bool visible = await removeButton.Nth(i).IsVisibleAsync();
                Console.WriteLine(visible
                    ? $"Remove button {i + 1} is visible"
                    : $"Remove button {i + 1} is not visible");
            }
        }

        // Verify Continue Shopping button
        public async Task ContinueShoppingButton()
        {
            bool visible = await continueShoppingButton.IsVisibleAsync();
            Console.WriteLine(visible
                ? "Continue Shopping button visible"
                : "Continue Shopping button not visible");
        }


        // Verify Checkout button
        public async Task CheckoutButton()
        {
            bool visible = await checkOutButton.IsVisibleAsync();
            Console.WriteLine(visible
                ? "Checkout button visible"
                : "Checkout button not visible");
        }




        /*    public async Task<bool> VerifyContinueShoppingbuttons()
            {
                bool isVisibleContinueShoppingButton = await removeButton.IsVisibleAsync();
                if (isVisibleContinueShoppingButton)
                {
                    Console.WriteLine("Continue Shopping button visible");
                }
                else
                {
                    Console.WriteLine("Continue Shopping button not visible");
                }
                return isVisibleContinueShoppingButton;

            }
            public async Task<bool> VerifyCheckoutbuttons()
            {
                bool isVisibleCheckoutButton = await removeButton.IsVisibleAsync();
                if (isVisibleCheckoutButton)
                {
                    Console.WriteLine("Checkout button visible");
                }
                else
                {
                    Console.WriteLine("Checkout button not visible");
                }
                return isVisibleCheckoutButton;

            }

        }*/
    }
}
