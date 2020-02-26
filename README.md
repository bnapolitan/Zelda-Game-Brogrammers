# 3902 Project - Sprint 2, Brogrammers

## Program controls

Player controls:
 - WASD or arrow keys to move around.
 - Z or N to attack with sword
 - E to damage Link
 - 1 to throw a boomerang
 - 2 to use the blue candle

Environment cycling:
 - Left click go forwards in the cycle
 - Right click to go backwards in the cycle

Enemy/NPC cycling:
 - P to go fowards in the cycle
 - O to go backwards in the cycle

Item cycling:
 - I to go forwards in the cycle
 - U to go backwards in the cycle


##Code analysis (FxCop)

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



##Code analysis (Codacy)
