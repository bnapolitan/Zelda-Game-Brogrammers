using Microsoft.Xna.Framework;

namespace Project3902.GameObjects.Environment
{
    class BlackBackground : FixedGameObject, IBackgroundEnvironmentObject
    {

        public BlackBackground(Vector2 position)
            : base(position) { }

        public void MoveLeft()
        {
            this.Position += new Vector2(-5, 0);
        }

        public void MoveRight()
        {
            this.Position += new Vector2(5, 0);
        }

    }
}
