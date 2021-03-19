Feature: Update Personal details 
Scenario: Update first name 
 Given user is loggged in to the Shopping Portal already
   When the user clicks on the Name and updates first name 
  Then user should be able to see the updated name in account details