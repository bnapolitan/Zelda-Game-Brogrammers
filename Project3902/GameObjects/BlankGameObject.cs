using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902.GameObjects
{
    class BlankGameObject: IGameObject, ICollidable
    {
        public Vector2 Position { get; set; }

        public ISprite Sprite { get; set; }

        public bool Active { get; set; }

        public Collider Collider { get; set; }

        public BlankGameObject(Vector2 pos)
        {
            Position = pos;

        }
        public void Update(GameTime gameTime)
        {
            Collider.AlignHitbox();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Collider.Draw(spriteBatch);
        }

        public void OnCollide(Collider other)
        {

        }
    }
}
