﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Active)
                return;
            Collider.Draw(spriteBatch);
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
            throw new NotImplementedException();
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!Active)
                return;

            Sprite.Update(gameTime);
        }
    }
}