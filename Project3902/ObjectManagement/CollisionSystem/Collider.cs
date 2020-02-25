using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class Collider : IUpdatable, IDrawable
    {
        private bool debug = true;

        // Local to GameObject.
        Rectangle rect;

        // In World space
        public Rectangle Hitbox { get; set; }

        public IGameObject GameObject { get; set; }

        public Collider(IGameObject gameObject, Rectangle localHitbox)
        {
            GameObject = gameObject;
            rect = localHitbox;
            AlignHitbox();
        }

        public void Update(GameTime gameTime)
        {
            AlignHitbox();
        }

        public bool Intersects(Collider other)
        {
            return Hitbox.Intersects(other.Hitbox);
        }

        private void AlignHitbox()
        {
            var gameObjectPosition = GameObject.Position.ToPoint();

            Hitbox = new Rectangle(rect.X + gameObjectPosition.X, rect.Y + gameObjectPosition.Y, rect.Width, rect.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (debug)
                spriteBatch.Draw(ShapeSpriteFactory.Instance.WhiteRect, Hitbox, new Rectangle(0, 0, 1, 1), Color.Red);
        }
    }
}
