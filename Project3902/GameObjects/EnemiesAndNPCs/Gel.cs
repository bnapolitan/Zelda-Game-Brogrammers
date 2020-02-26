﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class Gel: BaseEnemy
    {
        private readonly float speed;
        private readonly float distance=100;
        private Vector2 relPos=new Vector2(0,0);
        private Vector2 direction;

        public Gel(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Active = true;
            speed = moveSpeed;
            direction = initDirection;
        }
        public override void TakeDamage()
        {

        }
        public override void Attack()
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Position+=direction * speed;
            relPos+=direction*speed;
            if (relPos.X > distance)
            {
                direction *= -1;
                relPos = new Vector2(0, 0);
            }
            else if (relPos.X< -distance)
            {
                direction *= -1;
                relPos=new Vector2(0,0);
            }
        }

        public override void OnCollide(Collider other)
        {
        }
    }
}