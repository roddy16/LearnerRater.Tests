Feature: NewResourcePage
	In order to add resources to the LearnerRater site
	As a contributor
	I want to:

Scenario: Display Add Resource Link screen
	Given I have accessed the resources page
	When I click the Add Resource Link button
	Then The add new resource link form should be displayed

Scenario Outline: Add a New Resource
	Given I have accessed the resources page
		And I have clicked the Add Resource Link button
		And I have entered a resource with <subject>, <title>, <author>, <description>, <website>, <link>, <username>, <rating> and <comments>
	When I click the Resource Submit button
	Then I should be redirected to the <subject> resource page
		And The new resource <title>, <author>, <description>, <website> and <link> should display
		And The new resource should have <comments> by <username> listed
		And The total count of resources for that subject should be incremented by 1
	Examples: 
	| subject | title            | author    | description             | website    | link					 | username | rating   | comments           |
	| NCrunch | Crunching N Time | Dr. Suess | Learn all about NCrunch | LearnStuff | http://learnstuff.com/ | sRods    | Rating_5 | It was awesome!!!! |

Scenario Outline: Cancel a New Resource
	Given I have accessed the resources page
		And I have clicked the Add Resource Link button
		And I have entered a resource with <subject>, <title>, <author>, <description>, <website>, <link>, <username>, <rating> and <comments>
	When I click the Resource Cancel button
	Then The form should close
		And The new resource <title> by <author> about <description> on <website> at <link> should not be added to the resource page
	Examples: 
	| subject	 | title		       | author       | description                 | website | link				  | username | rating   | comments       |
	| JavaScript | JavaScript Not Java | J.S. Manwell | Learn javascript not Java   | JS Site | http://jssite.com/    | sRods    | Rating_1 | It was meh!!!! |
