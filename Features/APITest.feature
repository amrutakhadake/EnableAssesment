Feature: Buggy Car API Test

Determine the API call details behind this URL: https://buggy.justtestit.org/overall
Then, use them to replicate the call via a tool of your choice (e.g. postman, SoapUI, Insomnia,
etc.). The expected response is that it will retrieve page 1 of the car models list. Provide the a
screenshot of your (actual) replicated API call and the corresponding response.

@API
Scenario: Get list of car models from overall endpoint
    Given I send a GET request to "/api/models?page=1&size=10"
    Then the response status code should be 200
    And the response should contain a list of car models