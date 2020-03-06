# 3902 Project - Sprint 2, Brogrammers

## Program controls

Player Controls:
 - WASD or arrow keys to move around.
 - Z or N to attack with sword
 - E to damage Link
 - 1 to throw a boomerang
 - 2 to use the blue candle

Level Controls:
 - Left click to switch to previous level
 - Right click to switch to next level

## Explanation of MouseActions and InputState
We use MouseActions to map a specific mouse button to a command. Monogame does not have a representation of mouse buttons that can be used in such a way, there is only LeftButton (and similar) properties of a MouseState instance, but as that is an instance variable of type ButtonState, it can't be used as a key in a dictionary. That said, MouseState.LeftButton is in fact used inside the MouseController to determine if the command associated with MouseActions.Left should be executed. Similarly, InputState is used instead of ButtonState for the simple reason that ButtonState does not include a "Held" option. InputState allows us to take a certain key or button with a certain command, and specify what type of input should cause the command to be executed (key just pressed, key held, or key just released).

## Code analysis (FxCop) Sprint 3

There were 7 errors returned from the code analyzer. The first 6 were related to the String parser that we
used for the level builder. We chose to suppress these warnings because the input files will be a consistent
format so the parser will also be consistent. The final warning was unrelated to our code and was related to
the FxCop Analyizer.
