﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    abstract class BasePlayerProjectile : IProjectile
    {

        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Collider Collider { get; set; }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!Active)
                return;
            Collider.Draw(spriteBatch);
            if (Sprite != null)
                Sprite.Draw(spriteBatch);
        }

        public virtual void Launch(Vector2 position, Vector2 direction)
        {
            Position = position;
            Direction = direction;

            Active = true;
        }

        public virtual void OnCollide(Collider other)
        {
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!Active)
                return;

            if (Sprite != null)
                Sprite.Update(gameTime);
        }
    }
}
