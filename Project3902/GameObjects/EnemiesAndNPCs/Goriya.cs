using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.ObjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects.EnemiesAndNPCs
{
    class Goriya : ProjectileLaunchingEnemy
    {
        private readonly float distance = 100;
        private Vector2 relPos = new Vector2(0, 0);
        public ISprite rightFacingGoriya;
        public ISprite leftFacingGoriya;
        public ISprite downFacingGoriya;
        public ISprite upFacingGoriya;
        private readonly int framesBeforeAttack = 180;
        private int currentFrame = 0;
        private IProjectile boomerang;
        private bool isShooting = false;

        public Goriya(Vector2 pos, float moveSpeed, Vector2 initDirection) : base(pos, moveSpeed, initDirection) {
            Health = 2;
        }

        public override void Attack()
        {
            boomerang = WeaponFactory.Instance.CreateBoomerangProjectile(Position, Direction);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (isShooting)
            {
                boomerang.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (currentFrame >= framesBeforeAttack)
            {
                this.Attack();
                isShooting = true;
                currentFrame = 0;
            }

            if (!isShooting)
            {
                Position += Direction * MoveSpeed;
                relPos += Direction * MoveSpeed;
                if (relPos.X > distance)
                {
                    Direction = new Vector2(0, 1);
                    Sprite = downFacingGoriya;
                    relPos = new Vector2(0, 0);
                }
                else if (relPos.Y > distance)
                {
                    Direction = new Vector2(-1, 0);
                    Sprite = leftFacingGoriya;
                    relPos = new Vector2(0, 0);
                }
                else if (relPos.X < -distance)
                {
                    Direction = new Vector2(0, -1);
                    Sprite = upFacingGoriya;
                    relPos = new Vector2(0, 0);
                }
                else if (relPos.Y < -distance)
                {
                    Direction = new Vector2(1, 0);
                    Sprite = rightFacingGoriya;
                    relPos = new Vector2(0, 0);
                }
            }

            currentFrame++;

            if (isShooting)
            {
                boomerang.Update(gameTime);
                if (!boomerang.Active)
                {
                    isShooting = false;
                    currentFrame = 0;
                }
            }
        }

        

        public override void TakeDamage()
        {
            throw new NotImplementedException();
        }
    }
}