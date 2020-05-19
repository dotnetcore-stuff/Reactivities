Feature: Get goods
    In am in need of some goods
    I want to place the order successfully

Background:
    Given A configured environment

Scenario: I should be able to place an order successfully
    Given You have a need to buy some goods
    When You place an order
    Then The order message should get published successfully
