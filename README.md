# 3902 Project - Sprint 4, Brogrammers

## Program controls

Player Controls:
	Keyboard:
 		- WASD or arrow keys to move around
 		- 1 to throw a boomerang 
 		- 2 to use the blue candle
		- 3 to use bombs (when count>0)
		- 4 to use bow/arrow 
		- Z to use weapon in slot A (sword)
		- X to use weapon in slot B (sword is default, first weapon to get picked up other than sword gets automatically assigned, switch in inventory menu)
		- Shift to sprint
		- Note: keys 1-4 are for ease of testing for TA, Z and X keys replicate actual game functioning
		- Note: we are assuming Link has already picked up or bought arrows before he enters the dungeon and picks up the bow
 	Gamepad:
		- DPad or Left Stick to move around
		- A to use weapon in slot A (sword)
		- B to use weapon in slot B
		- Click Left Stick to sprint

General Game/Menu Controls:	
	Keyboard:	
		- G to start game, toggle inventory pause state, or restart after death
		- H to toggle general pause state (with frozen screen)
		- C to continue after death
		- ESC to exit game
		- 0 to toggle traditional or custom sounds
		- WASD or arrow keys to move selector in inventory screen
		- Z to select item in inventory screen
		- Clicking rooms with mouse on the HUD map will instantly switch to those levels
	Gamepad:
		- Start Button to start game, toggle inventory pause state, or restart after death
		- Back Button to toggle general pause state (with frozen screen) or continue after death
		- B button to exit game when game isn't in run state (in a menu not including inventory)
		- DPad or Left Stick to move selector in inventory screen
		- A to select item in inventory screen

Note About Levels:

Instead of having Link start from the first dungeon room, we have him start from a "Room 0"
From here, he can go left to enter the Survival Room, where he can earn extra coins and a heart container if he successfully fights through the waves.
He can go right to enter the BulletHell Room, where he can test his speed and agility.
Going up from this room will result in Link entering the classic first room of the first dungeon. All rooms from here are standard.

## Explanation of MouseActions and InputState
We use MouseActions to map a specific mouse button to a command. Monogame does not have a representation of mouse buttons that can be used in such a way, there is only LeftButton (and similar) properties of a MouseState instance, but as that is an instance variable of type ButtonState, it can't be used as a key in a dictionary. That said, MouseState.LeftButton is in fact used inside the MouseController to determine if the command associated with MouseActions.Left should be executed. Similarly, InputState is used instead of ButtonState for the simple reason that ButtonState does not include a "Held" option. InputState allows us to take a certain key or button with a certain command, and specify what type of input should cause the command to be executed (key just pressed, key held, or key just released).

FxCop Sprint 4

Work-in-progress:

Fixed:
    - The field 'FinalGame.freezeEnemiesTime' is assigned but its value is never used	FinalGame.cs	48
    - Parameter gameTime of method DrawText is never used. Remove the parameter or use it in the method body.	Project3902	E:\Git\Zelda-Game-Brogrammers\Project3902\FinalGame.cs	299	Active


Supressed:
    - The behavior of 'float.Parse(string)' could vary based on the current user's locale settings. Replace this call in 'LevelBuilder.CreateInteractiveEnvironmentObjects()' with a call to 'float.Parse(string, IFormatProvider)'.	Project3902	E:\Git\Zelda-Game-Brogrammers\Project3902\LevelBuilding\LevelBuilder.cs	63	Active
        Appeared many times, parsing is consistent enough for our uses
    - The behavior of 'string.Equals(string)' could vary based on the current user's locale settings. Replace this call in 'Project3902.ObjectManagement.SoundHandler.PlaySong(string)' with a call to 'string.Equals(string, System.StringComparison)'.	Project3902	E:\Git\Zelda-Game-Brogrammers\Project3902\ObjectManagement\SoundHandler.cs	61	Active
        Same reasons as above, string equals is accurate enough for our use
    - The behavior of 'float.Parse(string)' could vary based on the current user's locale settings. Replace this call in 'LevelBuilder.CreateItemObjects()' with a call to 'float.Parse(string, IFormatProvider)'.	Project3902	E:\Git\Zelda-Game-Brogrammers\Project3902\LevelBuilding\LevelBuilder.cs	98	Active
        Accurate enough for us (still using same settings)
    - The behavior of 'char.ToString()' could vary based on the current user's locale settings. Replace this call in 'FinalGame.DrawText()' with a call to 'char.ToString(IFormatProvider)'.	Project3902	E:\Git\Zelda-Game-Brogrammers\Project3902\FinalGame.cs	331	Active
        Still not worried about parsing methods



