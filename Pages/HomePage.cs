using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PlaywrightSauceDemoFramework.Framework;
using PlaywrightSauceDemoFramework.Framework.Base;

namespace PlaywrightSauceDemoFramework.Pages
{
    public class HomePage :BasePage
    {
        public HomePage(IPage page) : base(page) { }

        // Locators
        private ILocator allProducts => page.Locator(".inventory_item");
        private ILocator cartItem => page.Locator("[data-test='shopping-cart-link']");
        private ILocator backToProduct => page.Locator("[data-test='back-to-products']");

        // Click product title by index to go to product detail page
        public async Task OpenProductByIndex(int index = 0)
        {
            var product = allProducts.Nth(index);
            var title = product.Locator(".inventory_item_name");
            await title.ClickAsync();
            Console.WriteLine($"Opened product {index + 1} details page");
        }

        // Add product to cart from product detail page
        public async Task AddToCartFromProductDetail()
        {
            var addButton = page.Locator("button:has-text('Add to cart')");
            await addButton.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await addButton.ClickAsync();
            Console.WriteLine("Added product to cart from product detail page");
        }
        //Continue shopping for another product
        public async Task ContinueShopping()
        {
            await backToProduct.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible ,
            Timeout =60000});
            await backToProduct.ClickAsync();
            Console.WriteLine("Clicked Continue Shopping button to go back to products");
        }

        // Open cart
        public async Task ViewCart()
        {
            await cartItem.ClickAsync();
            await page.WaitForURLAsync("**/cart.html");
            Console.WriteLine("Navigated to cart page");
        }
    }
















   
}
