using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using PlaywrightSauceDemoFramework.Framework.Hooks;
using System;
using System.Net;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TechTalk.SpecFlow;
using FluentAssertions;
using NUnit.Framework;


namespace PlaywrightSauceDemoFramework.StepDefinitions
{
    [Binding]
    public class APITesting
    {
        private IAPIRequestContext api => Hooks.ApiContext;
        private IAPIResponse response;
        private JObject responsebody;

        
            [Given(@"I send a GET request to ""([^""]*)""")]
            public async Task GivenISendAGETRequestTo(string endpoint)
            {
                response = await api.GetAsync(endpoint);
                var body = await response.TextAsync();
                TestContext.WriteLine(body);   // prints response

                 responsebody = JObject.Parse(body);
            }


            [Then(@"the response status code should be (.*)")]
            public async Task ThenTheResponseStatusCodeShouldBe(string endpoint)
            {
            response = await api.GetAsync(endpoint);
            var bodyText=await response.TextAsync();
            responsebody=JObject.Parse(bodyText);
                
            }

        [Then(@"the response should contain a list of car models")]
        public void ThenTheResponseShouldContainAListOfCarModels()
        {

            if (!responsebody.TryGetValue("cars", out var carsToken)) ;
            {
                Assert.Fail("Response does not contain 'cars' key");
            }
            var carsArray = carsToken as JArray;

            if (carsArray == null)
            {
                Assert.Fail("'cars' key is not a JSON array");
            }


            foreach (var car in carsArray)
            {
                var name = car["name"]?.ToString() ?? "Unknown";
                var model = car["model"]?.ToString() ?? "Unknown";
                TestContext.WriteLine($"Car: {name}, Model: {model}");
            }

        }
    }
    }
