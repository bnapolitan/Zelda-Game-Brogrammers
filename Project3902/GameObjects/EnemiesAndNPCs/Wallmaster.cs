using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects.EnemiesAndNPCs.Interfaces
{
    class Wallmaster : BaseEnemy
    {
        private float speed;
        private float distance = 100;
        private Vector2 relPos = new Vector2(0, 0);
        private Vector2 direction;
        public ISprite RightFacingWallmaster { get; set; }
        public ISprite LeftFacingWallmaster { get; set; }

        public Wallmaster(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Active = true;
            speed = moveSpeed;
            direction = initDirection;
        }

        public override void Update(GameTime gameTime)
        {
            Position += direction * speed;
            relPos += direction * speed;
            if (relPos.X > distance)
            {
                direction *= -1;
                Sprite = LeftFacingWallmaster;
                relPos = new Vector2(0, 0);
            }
            else if (relPos.X < -distance)
            {
                direction *= -1;
                Sprite = RightFacingWallmaster;
                relPos = new Vector2(0, 0);
            }

            base.Update(gameTime);
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void OnCollide(Collider other)
        {
            throw new NotImplementedException();
        }

        public override void TakeDamage()
        {
            throw new NotImplementedException();
        }

    }
}