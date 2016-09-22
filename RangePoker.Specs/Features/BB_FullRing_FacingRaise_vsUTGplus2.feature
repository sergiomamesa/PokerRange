Feature: BB_FullRing_FacingRaise_vsUTGplus2
	In order to know what action to take in a 6-max full table
	As a BB Positioned player
	I want to be told the action

@mytag
Scenario: Hero is BB - full table
	Given a full ring player table
	And table is full
	And Hero is BB
	And Hero has 0, 1, 2, 1
	And UTG plus two raises
	When Action reaches Hero
	Then Hero is told to take action 5