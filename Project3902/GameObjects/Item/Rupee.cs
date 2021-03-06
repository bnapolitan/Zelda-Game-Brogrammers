﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;

namespace Project3902
{
    class Rupee : IItem
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Collider Collider { get; set; }

        public Rupee(Vector2 pos)
        {
            Position = pos;
            Active = true;
        }
        public void TakeDamage()
        {

        }
        public void Attack()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            {
                Sprite.Draw(spriteBatch);
                Collider.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public void OnCollide(Collider other)
        {
        }
    }
}