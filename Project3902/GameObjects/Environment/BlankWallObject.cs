using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902.GameObjects
{
    class BlankWallObject: IInteractiveEnvironmentObject
    {
        public Vector2 Position { get; set; }

        public ISprite Sprite { get; set; }

        public bool Active { get; set; } = true;

        public Collider Collider { get; set; }

        public BlankWallObject(Vector2 pos)
        {
            Position = pos;

        }
        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public void OnCollide(Collider other)
        {

        }
    }
}
