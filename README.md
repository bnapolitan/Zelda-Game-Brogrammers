# 3902 Project - Sprint 5, Brogrammers

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

FxCop Sprint 5

Fixed:
	- Unused field 'Factory'.	Project3902	E:\Git\Zelda-Game-Brogrammers\Project3902\GameObjects\GameScreens\StartMenuState.cs	14	Active
	- The using directive for 'System.Collections.Generic' appeared previously in this namespace	Project3902	E:\Git\Zelda-Game-Brogrammers\Project3902\Controllers\GamepadController.cs	7	Active
	- Parameter pos of method CreateArrowProjectile is never used. Remove the parameter or use it in the method body.	Project3902	E:\Git\Zelda-Game-Brogrammers\Project3902\ObjectManagement\WeaponFactory.cs	174	Active
	- Method 'void GameOverState.createElements()' passes a literal string as parameter 'text' of a call to 'IDrawable HUDFactory.createTextSection(SpriteFont font, string text)'. Retrieve the following string(s) from a resource table instead: " Press C to continue\n Press G to restart\n Press ESC to exit game\n".	Project3902	E:\Git\Zelda-Game-Brogrammers\Project3902\GameObjects\GameScreens\GameOverState.cs	38	Active
		Moved into configuration
	- 'ITextSprite.Draw(SpriteBatch)' hides inherited member 'IDrawable.Draw(SpriteBatch)'. Use the new keyword if hiding was intended.	Project3902	E:\Git\Zelda-Game-Brogrammers\Project3902\Text\ITextSprite.cs	14	Active


Supressed:
	- The behavior of 'string.Equals(string)' could vary based on the current user's locale settings. Replace this call in 'Project3902.FinalGame.MouseSwitchRoom(string)' with a call to 'string.Equals(string, System.StringComparison)'.	Project3902	E:\Git\Zelda-Game-Brogrammers\Project3902\FinalGame.cs	459	Active
        String equals is accurate enough for our use
	- Method 'void GameOverState.createElements()' passes a literal string as parameter 'text' of a call to 'IDrawable HUDFactory.createTextSection(SpriteFont font, string text)'. Retrieve the following string(s) from a resource table instead: "Game Over! ".	Project3902	E:\Git\Zelda-Game-Brogrammers\Project3902\GameObjects\GameScreens\GameOverState.cs	39	Active
		More helpful to programmer here; able to visually see the "Game Over" text
	- Member CreateStartLinkController does not access instance data and can be marked as static (Shared in VisualBasic)	Project3902	E:\Git\Zelda-Game-Brogrammers\Project3902\ObjectManagement\LinkFactory.cs	112	Active
		Easier to keep everything under the "LinkFactory.Instance" to avoid confusion. This change would prevent us from accessing the methods in instances.



