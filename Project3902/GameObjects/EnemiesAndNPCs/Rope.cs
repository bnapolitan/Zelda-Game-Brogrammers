using Microsoft.Xna.Framework;
using System;

namespace Project3902.GameObjects.EnemiesAndNPCs
{
    class Rope : BaseEnemy
    {
        private readonly float distance = 100;
        private Vector2 relPos = new Vector2(0, 0);
        public ISprite RightFacingRope { get; set; }
        public ISprite LeftFacingRope { get; set; }

        public Rope(Vector2 pos, float moveSpeed, Vector2 initDirection)
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
            if (relPos.X > distance)
            {
                Direction *= -1;
                Sprite = LeftFacingRope;
                relPos = new Vector2(0, 0);
            }
            else if (relPos.X < -distance)
            {
                Direction *= -1;
                Sprite = RightFacingRope;
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