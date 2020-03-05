using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Project3902.GameObjects.EnemiesAndNPCs
{
    class Goriya : ProjectileLaunchingEnemy
    {
        private float steps = 100;
        public ISprite rightFacingGoriya;
        public ISprite leftFacingGoriya;
        public ISprite downFacingGoriya;
        public ISprite upFacingGoriya;
        private readonly int framesBeforeAttack = 200;
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
                if (steps == 0)
                {
                    Random random = new Random();
                    int dvalue = random.Next(4);
                    switch (dvalue)
                    {
                        case 0:
                            Direction = new Vector2(1, 0);
                            Sprite = rightFacingGoriya;
                            break;
                        case 1:
                            Direction = new Vector2(-1, 0);
                            Sprite = leftFacingGoriya;
                            break;
                        case 2:
                            Direction = new Vector2(0, 1);
                            Sprite = downFacingGoriya;
                            break;
                        case 3:
                            Direction = new Vector2(0, -1);
                            Sprite = upFacingGoriya;
                            break;
                    }
                    steps = random.Next(40, 300);
                }
                Position += Direction * MoveSpeed;
                steps--;
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