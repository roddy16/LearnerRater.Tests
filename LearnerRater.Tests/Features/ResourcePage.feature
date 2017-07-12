Feature: ResourcePage
	In order to rate and view certain resources
	As a reviewer
	I want to:

Scenario: Show Reviews
	Given I have selected 'Git' as the category
	When I click Show Reviews
	Then all the reviews should be displayed
		And the button should read Hide Reviews

Scenario: Hide Reviews 
	Given I have selected 'Git' as the category
		And I have clicked Show Reviews
	When I click Hide Reviews
	Then all the reviews should be hidden
		And the button should read Show Reviews

Scenario: Display Review Overlay
	Given I have selected 'Git' as the category
	When I click You Be The Judge button
	Then the Add Review overlay should appear

Scenario: Add a Review
	Given I have selected 'Git' as the category
		And I have opened the Add Review overlay
		And I have entered the following review
		| Username         | Rating | Comment        |
		| Mr. Bigglesworth | 2      | It was just ok |
	When I click the Submit button
	Then the overlay should close
		And the new review should display the information entered
		And the total count of reviews for that resource should be incremented by 1

Scenario: Cancel Adding a Review
	Given I have selected 'Git' as the category
		And I have opened the Add Review overlay
		And I have entered the following review
		| Username     | Rating | Comment          |
		| TuffReviewer | 1      | I didn't like it |
	When I click the Cancel button
	Then the overlay should close
		And the new review should not be added to the resource

Scenario: Delete a Review
	Given I have selected 'Git' as the category
		And I have opened the Add Review overlay
		And I have entered the following review
		| Username     | Rating | Comment          |
		| TuffReviewer | 1      | I didn't like it |
		And I have clicked the Submit button
		And I have clicked Show Reviews
		And I have clicked the manage button
	When I click the review Delete button
	Then the review should be deleted from the resource
		And the total count of reviews for that resource should be reduced by 1

Scenario: Delete a Resource
	Given I have selected 'JavaScript' as the category
		And I have clicked the Add Resource Link button
		And I have entered the following resource
		| Category	 | Title		       | Author       | Description                 | Website | Link				  | Username | Rating   | Comment       |
		| JavaScript | JavaScript Not Java | J.S. Manwell | Learn javascript not Java   | JS Site | http://jssite.com/    | sRods    | 1 | It was meh!!!! |
		And I have clicked the Resource Submit button
		And I have clicked the manage button
	When I click the resource Delete button
	Then the new resource should not be added to the resource page
		And the total count of resources for that subject should be reduced by 1

Scenario: Add a Review without Username or Star Rating
	Given I have selected 'Git' as the category
		And I have opened the Add Review overlay
	When I click the Submit button
	Then I should get '2' error messages
		And the error text should read 'Required'

Scenario: Add a Review with a long Username
	Given I have selected 'Git' as the category
		And I have opened the Add Review overlay
		And I have entered the following review
		| Username                                            | Rating | Comment          |
		| ThisIsAVeryLongUserNameThatShouldNotPassValidation! | 1      | I didn't like it |
	When I click the Submit button
	Then I should get '1' error message
		And the error text should read 'Exceeded max field size'
<<<<<<< Updated upstream
=======
	Examples: 
	| username											  | starRating | comments		  |
	| ThisIsAVeryLongUserNameThatShouldNotPassValidation! | Rating_1   | I didn't like it |
>>>>>>> Stashed changes
		