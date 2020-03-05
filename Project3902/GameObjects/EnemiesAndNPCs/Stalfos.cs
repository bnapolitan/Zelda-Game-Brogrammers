using Microsoft.Xna.Framework;
using System;

namespace Project3902.GameObjects.EnemiesAndNPCs
{
    class Stalfos : BaseEnemy
    {
        private int steps = 100;

        public Stalfos(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Active = true;
            MoveSpeed = moveSpeed;
            Direction = initDirection;
            Health = 2;
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);

            if (!attackedRecent)
            {
                if (steps == 0)
                {
                    Random random = new Random();
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