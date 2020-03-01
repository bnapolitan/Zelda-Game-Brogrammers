﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class Collider : IDrawable
    {
        private bool debug = false;

        private Rectangle localRect;

        public Rectangle Hitbox { get; set; }

        public IGameObject GameObject { get; set; }

        public Collider(IGameObject gameObject, Rectangle localHitbox)
        {
            GameObject = gameObject;
            localRect = localHitbox;
            AlignHitbox();
        }

        public bool Intersects(Collider other)
        {
            return Hitbox.Intersects(other.Hitbox);
        }

        public void AlignHitbox()
        {
            var gameObjectPosition = GameObject.Position.ToPoint();

            Hitbox = new Rectangle(localRect.X + gameObjectPosition.X, localRect.Y + gameObjectPosition.Y, (int)GameObject.Sprite.Size.X * (int)GameObject.Sprite.Scale.X, (int)GameObject.Sprite.Size.Y * (int)GameObject.Sprite.Scale.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (debug)
                spriteBatch.Draw(ShapeSpriteFactory.Instance.WhiteRect, Hitbox, new Rectangle(0, 0, 1, 1), Color.Red);
        }
    }
}
