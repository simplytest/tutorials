Feature: Multiplication
  As a user i want to be able to muliply two integer numbers

  Scenario: Sunny Day Case: Multiply two positive numbers larger zero
    Given I open "Calculator" app
    When I enter 3 as first number and 4 as second number and trigger calculation
    Then I should get the result 12

  Scenario: Negative Case: Multiply a positive numbers with negative number
    Given I open "Calculator" app
    When I enter 3 as first number and -4 as second number and trigger calculation
    Then I should get the result -12

  Scenario: Border Case: Multiplication with zero
    Given I open "Calculator" app
    When I enter 3 as first number and 0 as second number and trigger calculation
    Then I should get the result 0