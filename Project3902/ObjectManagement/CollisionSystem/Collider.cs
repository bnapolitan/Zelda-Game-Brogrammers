using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class Collider : IDrawable
    {
        private readonly bool debug = true;
        private readonly Color tint = new Color(255, 0, 0, 100);

        private Rectangle localRect;

        public Rectangle Hitbox { get; set; }

        public Vector2 Offset { get; set; }

        public IGameObject GameObject { get; set; }

        public Collider(IGameObject gameObject, Rectangle localHitbox)
        {
            GameObject = gameObject;
            localRect = localHitbox;
            Offset = localRect.Location.ToVector2();

            AlignHitbox();
        }

        public bool Intersects(Collider other)
        {
            return Hitbox.Intersects(other.Hitbox);
        }

        public bool Intersects(Rectangle otherRect)
        {
            return Hitbox.Intersects(otherRect);
        }

        public void AlignHitbox()
        {
            var gameObjectPosition = GameObject.Position.ToPoint();
            Hitbox = new Rectangle(localRect.X + gameObjectPosition.X, localRect.Y + gameObjectPosition.Y, localRect.Width, localRect.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (debug && GameObject.Active)
                spriteBatch.Draw(ShapeSpriteFactory.Instance.WhiteRect, Hitbox, new Rectangle(0, 0, 1, 1), tint);
        }
    }
}
