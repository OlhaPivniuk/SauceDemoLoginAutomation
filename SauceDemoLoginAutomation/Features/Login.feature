Feature: Login functionality for SauceDemo

  Scenario: UC-1 Test Login form with empty credentials
    Given I open the login page
    When I clear the "Username" and "Password" fields
    And I click the "Login" button
    Then I should see an error message saying "Username is required"

  Scenario: UC-2 Test Login form with partial credentials
    Given I open the login page
    When I enter "standard_user" as the username
    And I clear the "Password" field
    And I click the "Login" button
    Then I should see an error message saying "Password is required"

  Scenario: UC-3 Test Login form with valid credentials
    Given I open the login page
    When I enter "standard_user" as the username
    And I enter "secret_sauce" as the password
    And I click the "Login" button
    Then I should see the dashboard title "Swag Labs"