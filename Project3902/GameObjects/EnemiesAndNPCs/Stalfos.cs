﻿using Microsoft.Xna.Framework;
using System;

namespace Project3902.GameObjects.EnemiesAndNPCs
{
    class Stalfos : BaseEnemy
    {
        private readonly float distance = 100;
        private Vector2 relPos = new Vector2(0, 0);

        public Stalfos(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Active = true;
            MoveSpeed = moveSpeed;
            Direction = initDirection;
            Health = 1;
        }

        public override void Update(GameTime gameTime)
        {
         
            Position += Direction * MoveSpeed;
            relPos += Direction * MoveSpeed;
            if (relPos.Y > distance)
            {
                Direction *= -1;
                relPos = new Vector2(0, 0);
            }
            else if (relPos.Y < -distance)
            {
                Direction *= -1;
                relPos = new Vector2(0, 0);
            }

            base.Update(gameTime);
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        

        public override void TakeDamage()
        {
            throw new NotImplementedException();
        }
    }
}