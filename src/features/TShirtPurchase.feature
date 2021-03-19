Feature: Tshirt Purchase 
Scenario: TShirt Purchase and order confirmation
 Given user is loggged in to the Shopping Portal
   When the user searches tshirt & pays for it
  Then user should be able to see the order confirmation