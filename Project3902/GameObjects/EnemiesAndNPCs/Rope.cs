using Microsoft.Xna.Framework;
using System;

namespace Project3902.GameObjects.EnemiesAndNPCs
{
    class Rope : BaseEnemy
    {
        private float steps = 100;
        public ISprite RightFacingRope { get; set; }
        public ISprite LeftFacingRope { get; set; }
        private static readonly Random random = new Random();
        public Rope(Vector2 pos, float moveSpeed, Vector2 initDirection)
            : base()
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
                Sprite = RightFacingRope;
            }
            else if (Direction.X == -1)
            {
                Sprite = LeftFacingRope;
            }
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
                            Sprite = RightFacingRope;
                            break;
                        case 1:
                            Direction = new Vector2(-1, 0);
                            Sprite = LeftFacingRope;
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