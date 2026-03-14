using System;
using TechTalk.SpecFlow;
using PlaywrightSauceDemoFramework.Pages;
using PlaywrightSauceDemoFramework.Framework.Hooks;

namespace PlaywrightSauceDemoFramework.StepDefinitions
{
    [Binding]
    public class SauceDemoCartTestStepDefinitions
    {
        LoginPage login;
        HomePage home;
        CartPage cart;
        public SauceDemoCartTestStepDefinitions()
        {
            login = new LoginPage(Hooks.Page);
            home = new HomePage(Hooks.Page);
            cart = new CartPage(Hooks.Page);
        }
        [Given(@"User login to application")]
        public async Task GivenUserLoginToApplication()
        {
            await login.Login("standard_user", "secret_sauce");
        }

        [When(@"User opens first product and add to cart")]
        public async Task WhenUserOpensFirstProductAndAddToCart()
        {
            await home.OpenProductByIndex(0);
            await home.AddToCartFromProductDetail();
           // await home.ContinueShopping();


        }

        [When(@"User go back to product page")]
        public async Task WhenUserGoBackToProductPage()
        {
            await home.ContinueShopping();
        }

        [When(@"User open second product and add to cart")]
        public async Task WhenUserOpenSecondProductAndAddToCart()
        {
            await home.OpenProductByIndex(1);
            await home.AddToCartFromProductDetail();
        }

            [When(@"User open cart")]
            public async Task WhenUserOpenCart()
            {
                await home.ViewCart();
            }

            [Then(@"Cart page should show Remove ContinueShopping and Checkout buttons")]
            public async Task ThenCartPageShouldShowRemoveContinueShoppingAndCheckoutButtons()
            {
                await cart.VerifyRemoveButton();
                await cart.ContinueShoppingButton();
                await cart.CheckoutButton();
            }
        }
    }

