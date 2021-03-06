﻿using Microsoft.Xna.Framework;

namespace Project3902.GameObjects.EnemiesAndNPCs
{
    class Keese : BaseEnemy
    {
        private readonly float distance = 100;
        private Vector2 relPos = new Vector2(0, 0);

        public Keese(Vector2 pos, float moveSpeed, Vector2 initDirection)
            : base()
        {
            Position = pos;
            Active = true;
            MoveSpeed = moveSpeed;
            Direction = initDirection;
            Health = 1;
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
            if (cloudTimer > 0)
                return;

            if (!attackedRecent)
            {
                Position += Direction * MoveSpeed;
                relPos += Direction * MoveSpeed;
                if (relPos.X > distance)
                {
                    Direction *= -1;
                    relPos = new Vector2(0, 0);
                }
                else if (relPos.X < -distance)
                {
                    Direction *= -1;
                    relPos = new Vector2(0, 0);
                }
            }
        }

       
    }
}