# 3902 Project - Sprint 4, Brogrammers

## Program controls

Player Controls:
 - WASD or arrow keys to move around.
 - Z or N to attack with sword
 - 1 to throw a boomerang 
 - 2 to use the blue candle
 - G to pause
 (quickly spamming 1 or 2 will cut item usages short, but that won't be the case once item switching with the menu is implemented)

Level Controls:
 - Clicking rooms on the HUD map will instantly switch to those levels

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



