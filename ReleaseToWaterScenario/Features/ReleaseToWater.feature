Feature: ReleaseToWater
	

Scenario Outline: Add Two new records to release to water page 
	Given I navigate to the website "https://stirling.she-development.net/automation"
	And I enter the username and password as "OlugbengaO" and "Evo@47"  
	When I click on login button
	And I click on Module
	And I select Enviroment 
	And I click on Release To Water
	And I click on New Record
	And I enter the Description and Sample date 
	| description            | sampleDate |
	| This is the 1st record | 09/05/2022  |
	And I click on Save and Close button
    And I click on New Record
	And I enter the Description and Sample date 
	| description            | sampleDate |
	| This is the 2nd record | 10/05/2022  |
	And I click on Save and Close button
	Then the page title "Release To Water" page is displayed
	When I click on Cog setting icon of the first record in the manage records
	And I click on cog delete icon 
	Then the first record is deleted from the page
	And the second record is displayed on the page
	When I click on the user dropdown menu at the top of the page 
	And I click on logout
	Then I am logged out 
	And a pop up message with "You are now logged out. Click here to return to the Assure application." is displayed on the logout page  
	
	
