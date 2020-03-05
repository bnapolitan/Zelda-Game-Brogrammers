# 3902 Project - Sprint 2, Brogrammers

## Program controls

Player controls:
 - WASD or arrow keys to move around.
 - Z or N to attack with sword
 - E to damage Link
 - 1 to throw a boomerang
 - 2 to use the blue candle

## Known Bugs
1. Currently there are issues with wall collisions. If an enemy is shoved into a wall, it will become stuck, constantly changing direction every frame and not moving. Can also happen with projectiles if they happen to enter too far into a wall in a single frame. BaseLinkState.cs's MoveOutOfWall() is an example of how to fix this.
2. Door colliders are not scaled correctly, they only take up the top left quadrant.

## Explanation of MouseActions and InputState
We use MouseActions to map a specific mouse button to a command. Monogame does not have a representation of mouse buttons that can be used in such a way, there is only LeftButton (and similar) properties of a MouseState instance, but as that is an instance variable of type ButtonState, it can't be used as a key in a dictionary. That said, MouseState.LeftButton is in fact used inside the MouseController to determine if the command associated with MouseActions.Left should be executed. Similarly, InputState is used instead of ButtonState for the simple reason that ButtonState does not include a "Held" option. InputState allows us to take a certain key or button with a certain command, and specify what type of input should cause the command to be executed (key just pressed, key held, or key just released).

## Code analysis (FxCop)

19 Warnings:
Work-in-progress:
  - LinkUseItemCommand.cs - LinkUseItemCommand is an internal class that is apparently never instantiated. If so, remove the code from the assembly. If this class is intended to contain only static members, make it static (Shared in Visual Basic).
    Command will be used later

  - FixedItem.cs - Field 'FixedItem.game' is never assigned to, and will always have its default value null
    Fix this problem and refactor item classes



Fixed:
  - MultipleSource.cs - Line 31: Use Count property instead of IEnumerable Count
  - SimpleSprite.cs - Class is never used
      Deleted
  - WeaponFactoy.cs - Line 22: Unused field 'right'.
    Deleted
  - Aquamentus - Line 6: Remove the underscores from namespace name 'Project3902.GameObjects.Enemies_and_NPCs'.
  - Wallmaster.cs - Line 22&23: leftFacingWallmaster is never assigned and never used.
    Changed into Property



Surpressed:
  - FixedItem.cs - In externally visible method 'void FixedItem.Draw(SpriteBatch spriteBatch, Vector2 location)', validate parameter 'spriteBatch' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.
    spriteBatch will never be null as it is established inherently for every game run. If it is null we have way bigger problems.

  - Sprint0.cs - Line 160:Method 'void Sprint0.CreateText()' passes a literal string as parameter 'text' of a call to 'SimpleText.SimpleText(string text, Vector2 position, Color color, SpriteFont font, bool alignCenter = false)'. Retrieve the following string(s) from a resource table instead: "Sprites from: https://www.spriters-resource.com/nes/legendofzelda/sheet/8366/".
    This is unique to placing specific text for Sprint0 and is irrelevant to change. Literal strings will be extrapolated.

  - LinkStates.cs - Only FlagsAttribute enums should have plural names.
    It is clearer to describe it as plural states to show you are getting one of the many states.

  - Wall.cs, Statues.cs, etc. - Wall is an internal class that is apparently never instantiated. If so, remove the code from the assembly. If this class is intended to contain only static members, make it static (Shared in Visual Basic).
    Classes are not currently built in levels but will be later.

  - MouseActions.cs - Only FlagsAttribute enums should have plural names
    Also more clear for plural.
    
