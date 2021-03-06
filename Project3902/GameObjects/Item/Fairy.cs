﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;

namespace Project3902
{
    class Fairy : IItem
    {
        public float Health { get; set; }
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Collider Collider { get; set; }
        private readonly float speed;
        private readonly float distance = 100;
        private Vector2 relPos = new Vector2(0, 0);
        private Vector2 direction;

        public Fairy(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Active = true;
            speed = moveSpeed;
            direction = initDirection;
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
            Position += direction * speed;
            relPos += direction * speed;
            if (relPos.X > distance)
            {
                direction *= -1;
                relPos = new Vector2(0, 0);
            }
            else if (relPos.X < -distance)
            {
                direction *= -1;
                relPos = new Vector2(0, 0);
            }
            Sprite.Update(gameTime);
        }

        public void OnCollide(Collider other)
        {
        }
    }
}