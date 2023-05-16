Feature: PlayerCharacter
	In order to play the game
	As human player
	I want my character attributes to be correctly represented

Scenario Outline: Health reduction
	Given I'm a new player
	When I take <damage> damage
	Then My health should now be <remainingHealth>
Examples: 
	| damage | remainingHealth |
	| 0      | 100             |
	| 40     | 60              |

Scenario: Taking too much damage results in player death
	Given I'm a new player
	When I take 100 damage
	Then I should be dead