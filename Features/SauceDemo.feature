Feature: SauceDemo cart Test

User login with valid credentials and select product and add into cart
@AddProductinCart
Scenario: Add products and verify cart buttons

Given User login to application
When User opens first product and add to cart
And User go back to product page
And User open second product and add to cart
And User open cart
Then Cart page should show Remove ContinueShopping and Checkout buttons