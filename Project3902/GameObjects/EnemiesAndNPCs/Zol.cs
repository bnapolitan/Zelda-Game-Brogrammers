﻿using Microsoft.Xna.Framework;
using System;

namespace Project3902
{
    class Zol : BaseEnemy
    {
        private float steps = 100;
        private static readonly Random random = new Random();
        public Zol(Vector2 pos, float moveSpeed, Vector2 initDirection)
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
                if (steps == 0)
                {
                    int dvalue = random.Next(4);
                    switch (dvalue)
                    {
                        case 0:
                            Direction = new Vector2(1, 0);
                            break;
                        case 1:
                            Direction = new Vector2(-1, 0);
                            break;
                        case 2:
                            Direction = new Vector2(0, 1);
                            break;
                        case 3:
                            Direction = new Vector2(0, -1);
                            break;
                    }
                    steps = random.Next(40, 300);
                }
                Position += Direction * MoveSpeed;
                steps--;
            }
        }


    }
}