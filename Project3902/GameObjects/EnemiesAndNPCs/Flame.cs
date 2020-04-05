﻿using Microsoft.Xna.Framework;

namespace Project3902
{
    class Flame : BaseEnemy
    {
        private readonly float distance = 100;
        private Vector2 relPos = new Vector2(0, 0);

        public Flame(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Active = true;
            MoveSpeed = moveSpeed;
            Direction = initDirection;
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

        }

        
    }
}