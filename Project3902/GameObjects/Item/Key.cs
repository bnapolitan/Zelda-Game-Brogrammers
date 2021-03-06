﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;

namespace Project3902
{
    class Key : IItem
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Collider Collider { get; set; }

        public Key(Vector2 pos)
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
            Sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void OnCollide(Collider other)
        {
        }
    }
}