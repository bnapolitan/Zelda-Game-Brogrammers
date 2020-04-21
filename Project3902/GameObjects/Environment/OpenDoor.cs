using Microsoft.Xna.Framework;
using Project3902.GameObjects.Environment.Interfaces;

namespace Project3902.GameObjects.Environment
{
    class OpenDoor : BaseEnvironment, IDoorway
    {
        private FinalGame game;

        public OpenDoor(Vector2 position, FinalGame game)
            : base(position) { this.game = game; }

        public void ChangeLevel(string doorLocation)
        {
            if(doorLocation == "Top")
            {
                game.EnterRoomTop();
            }
            else if(doorLocation == "Left")
            {
                game.EnterRoomLeft();
            }
            else if (doorLocation == "Right")
            {
                game.EnterRoomRight();
            }
            else if (doorLocation == "Bottom")
            {
                game.EnterRoomBottom();
            }
        }
    }
}
