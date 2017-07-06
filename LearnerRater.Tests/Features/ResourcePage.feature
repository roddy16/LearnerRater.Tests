﻿Feature: ResourcePage
	In order to rate and view certain resources
	As a reviewer
	I want to:

Scenario: Show Reviews
	Given I have accessed the resources page
	When I click Show Reviews
	Then All the reviews should be displayed
		And The button should read Hide Reviews

Scenario: Hide Reviews 
	Given I have accessed the resources page
		And I have clicked Show Reviews
	When I click Hide Reviews
	Then All the reviews should be hidden
		And The button should read Show Reviews

Scenario: Display Review Overlay
	Given I have accessed the resources page
	When I click You Be The Judge button
	Then The Add Review overlay should appear

Scenario Outline: Add a Review
	Given I have accessed the resources page
		And I have opened the Add Review overlay
		And I have entered a review with <username>, <starRating> and <comments>
	When I click the Submit button
	Then The overlay should close
		And The review by <username> should be added to the resource with their <comments>
		And The total count of reviews for that resource should be incremented by 1
	Examples: 
		| username         | starRating | comments       |
		| Mr. Bigglesworth | Rating_2   | It was just ok |

Scenario Outline: Cancel Adding a Review
	Given I have accessed the resources page
		And I have opened the Add Review overlay
		And I have entered a review with <username>, <starRating> and <comments>
	When I click the Cancel button
	Then The overlay should close
		And The review by <username> should not be added to the resource with their <comments>
	Examples: 
		| username     | starRating | comments		   |
		| TuffReviewer | Rating_1   | I didn't like it |

Scenario Outline: Delete a Review
	Given I have accessed the resources page
		And I have opened the Add Review overlay
		And I have entered a review with <username>, <starRating> and <comments>
		And I have clicked the Submit button
		And I have clicked Show Reviews
		And I have clicked the manage button
	When I click the review Delete button
	Then The review by <username> with <comments> should be deleted from the resource
		And The total count of reviews for that resource should be reduced by 1
	Examples: 
		| username     | starRating | comments		   |
		| TuffReviewer | Rating_1   | I didn't like it |

Scenario Outline: Delete a Resource
	Given I have accessed the resources page
		And I have clicked the Add Resource Link button
		And I have entered a resource with <subject>, <title>, <author>, <description>, <website>, <link>, <username>, <rating> and <comments>
		And I have clicked the Resource Submit button
		And I have clicked the manage button
	When I click the resource Delete button
	Then The new resource <title> by <author> about <description> on <website> at <link> should not be added to the resource page
		And The total count of resources for that subject should be reduced by 1
	Examples: 
	| subject	 | title		       | author       | description                 | website | link				  | username | rating   | comments       |
	| JavaScript | JavaScript Not Java | J.S. Manwell | Learn javascript not Java   | JS Site | http://jssite.com/    | sRods    | Rating_1 | It was meh!!!! |

#this scenario needs to have at least one resource in order to work - didn't add to steps to add one since 
#eventually we will just have the db at the right state prior to running this test
Scenario: Add a Review without Username or Star Rating
	Given I have accessed the resources page
		And I have opened the Add Review overlay
	When I click the Submit button
	Then I should get 2 required field error messages 
		And The error text should read 'Required'
		