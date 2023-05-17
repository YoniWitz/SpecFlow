Feature: PlayerCharacter
	In order to play the game
	As human player
	I want my character attributes to be correctly represented

	Background: 
	Given I'm a new player

Scenario Outline: Health reduction
	When I take <damage> damage
	Then My health should now be <remainingHealth>
Examples: 
	| damage | remainingHealth |
	| 0      | 100             |
	| 40     | 60              |

Scenario: Taking too much damage results in player death
	When I take 100 damage
	Then I should be dead

Scenario: Elf race characters get additional 20 damage resistance
	And I have the following attributes
	| attribute         | value |
	| Race              | Elf   |
	| Resistance		| 10    |
	When I take <damage> damage
	Then My health should now be <remainingHealth>
Examples: 
	| damage | remainingHealth |
	| 0      | 100             |
	| 40     | 90              |

Scenario: Healers restore all health
	Given MY character class is set to Healer
	When I take 40 damage 
	And Cast a healing spell
	Then My health should now be 100
