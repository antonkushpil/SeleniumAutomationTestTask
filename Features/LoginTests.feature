Feature: LoginTests

@login
Scenario: 01. Login with facebook account
	Given I am on Login page
	And I click LoginWithFacebook button
	When I switch to 2 window
	And I login under TestUser account
	And I click Login button
	And I switch to 1 window
	Then I am on Home page

@login
@Ignore
Scenario Outline: 02. Login with incorrect credentials
	Given I am on Login page
	And I click LoginWithFacebook button
	When I switch to 2 window
	And I login under <User> account
	And I click Login button
	Then I see <Error> message

	Examples: 
	| Scenario       | User          | Error                           |
	| Empty UserName | EmptyUserName | Incorrect email or phone number |
	| Empty Password | EmptyPassword | Please re-enter your password   |

@search
	Scenario Outline: 03. Search with different keywords
	Given I am on Home page
	When I enter <Keyword> in search field
	Then I see <Result>

	Examples: 
	| Scenario     | Keyword   | Result                  |
	| Empty search |           | Nothing happens         |
	| Cats         | Cats      | Cats are shown          |
	| Dogs         | Dogs      | Dogs are shown          |
	| Cats & Dogs  | Cats Dogs | Cats and Dogs are shown |
