using Microsoft.Xna.Framework;
using System;

namespace Project3902.GameObjects.EnemiesAndNPCs.Interfaces
{
    class Wallmaster : BaseEnemy
    {
        private float steps = 100;
        public ISprite RightFacingWallmaster { get; set; }
        public ISprite LeftFacingWallmaster { get; set; }
        private static readonly Random random = new Random();
        public Wallmaster(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Active = true;
            MoveSpeed = moveSpeed;
            Direction = initDirection;
            Health = 1;
        }

        public override void OnCollide(Collider other)
        {
            base.OnCollide(other);
            if (Direction.X == 1)
            {
                Sprite = RightFacingWallmaster;
            }
            else if (Direction.X == -1)
            {
                Sprite = LeftFacingWallmaster;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!attackedRecent)
            {
                if (steps == 0)
                {
                    int dvalue = random.Next(4);
                    switch (dvalue)
                    {
                        case 0:
                            Direction = new Vector2(1, 0);
                            Sprite = RightFacingWallmaster;
                            break;
                        case 1:
                            Direction = new Vector2(-1, 0);
                            Sprite = LeftFacingWallmaster;
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