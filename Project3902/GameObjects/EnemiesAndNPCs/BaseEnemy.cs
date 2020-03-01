﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    abstract class BaseEnemy : IEnemy
    {
        public float Health { get; set; }

        private Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                if (Collider != null)
                    Collider.AlignHitbox();
            }
        }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Collider Collider { get; set; }

        public abstract void Attack();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Collider.Draw(spriteBatch);
            Sprite.Draw(spriteBatch);
        }

        public abstract void OnCollide(Collider other);

        public abstract void TakeDamage();

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
    }
}
