using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects.EnemiesAndNPCs
{
    class Zol : BaseEnemy
    {
        private readonly float distance = 100;
        private Vector2 relPos = new Vector2(0, 0);

        public Zol(Vector2 pos, float moveSpeed, Vector2 initDirection)
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
                relPos = new Vector2(0, 0);
            }
            else if (relPos.X < -distance)
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

        public override void OnCollide(Collider other)
        {
            base.OnCollide(other);
            if (Active == false)
            {
                
            }
        }

        public override void TakeDamage()
        {
            throw new NotImplementedException();
        }
    }
}
