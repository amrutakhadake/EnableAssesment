Playwright C# Automation Framework
Overview

This project is an automation testing framework built using C#, Playwright, and SpecFlow.
It demonstrates UI automation testing for the SauceDemo application and API testing for the BuggyCars application.

The framework follows BDD (Behavior Driven Development) practices and uses Page Object Model (POM) design for maintainability and scalability.
Technologies Used

C#

.NET

Playwright

SpecFlow

NUnit

Newtonsoft.Json

Visual Studio

Git & GitHub
Test Coverage
UI Automation – SauceDemo

Application:
https://www.saucedemo.com

Test scenarios automated:

Login with valid credentials

Login with invalid credentials

Add product to cart

Remove product from cart

Verify cart items

Checkout workflow

API Testing – BuggyCars

Application:
https://buggy.justtestit.org

API tests include:

Send GET request to retrieve vehicle information

Validate response status codes

Validate JSON response data

Verify API data structure

Libraries used for API testing:

HttpClient

Newtonsoft JSON parsing

Framework Design

The framework follows:

Page Object Model (POM)

Each page has its own class containing:

Page locators

Page actions

Reusable methods

BDD using SpecFlow

Test scenarios are written in Gherkin format.

Example:

Feature: Login functionality

Scenario: Login with valid credentials
Given I navigate to the login page
When I enter valid username and password
Then I should be logged in successfully
Setup Instructions
1 Install Prerequisites

.NET SDK

Visual Studio

Playwright CLI

Install Playwright:

playwright install
