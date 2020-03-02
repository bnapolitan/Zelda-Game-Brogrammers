using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Project3902
{
    class Gel : BaseEnemy
    {
        private float steps = 100;
        //private Vector2 relPos = new Vector2(0, 0);

        public Gel(Vector2 pos, float moveSpeed, Vector2 initDirection)
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

            /*Position += Direction * MoveSpeed;
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
            }*/
            if (steps == 0)
            {
                Random random = new Random();
                int dvalue = random.Next(4);
                switch(dvalue)
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
                steps = random.Next(40, 125);
            }
            Position += Direction * MoveSpeed;
            steps--;
        }

        
    }
}