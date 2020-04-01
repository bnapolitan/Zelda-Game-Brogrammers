using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects.EnemyProjectiles;
using Project3902.ObjectManagement;
using System;
using System.Collections.Generic;

namespace Project3902.GameObjects.EnemiesAndNPCs
{
    class BulletHellAquamentus : ProjectileLaunchingEnemy
    {
        public FinalGame Game { get; }
        private readonly float distance = 100;
        private Vector2 relPos = new Vector2(0, 0);
        private readonly int framesBeforeAttack = 180;
        private int currentFrame = 0;
        private IProjectile fireball;
        private IProjectile fireball2;
        private IProjectile fireball3;
        private int fireballDistance = 1200;
        private bool isShooting = false;

        public BulletHellAquamentus(Vector2 pos, float moveSpeed, Vector2 initDirection, FinalGame game) : base(pos, moveSpeed, initDirection)
        {
            this.Game = game;
            Sprite = EnemyFactory.Instance.CreateAquamentusSprite(this);
            Health = 5;
        }

        public override void Attack()
        {
            Vector2 fireball1Movement = Game.Link.Position - Position;
            fireball1Movement.Normalize();

            var angle = Math.Atan2(fireball1Movement.Y, fireball1Movement.X);

            fireball = WeaponFactory.Instance.CreateFireballProjectile(Position, fireball1Movement);
            fireball2 = WeaponFactory.Instance.CreateFireballProjectile(Position, new Vector2(fireball1Movement.X, (float)Math.Sin(angle + .524)));
            fireball3 = WeaponFactory.Instance.CreateFireballProjectile(Position, new Vector2(fireball1Movement.X, (float)Math.Sin(angle - .524)));

            (fireball as Fireball).distance = fireballDistance;
            (fireball2 as Fireball).distance = fireballDistance;
            (fireball3 as Fireball).distance = fireballDistance;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (isShooting)
            {
                fireball.Draw(spriteBatch);
                fireball2.Draw(spriteBatch);
                fireball3.Draw(spriteBatch);
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
            currentFrame++;

            if (isShooting)
            {
                fireball.Update(gameTime);
                fireball2.Update(gameTime);
                fireball3.Update(gameTime);
            }
        }

        public override void OnCollide(Collider other) {
            base.OnCollide(other);
        }

        public override void TakeDamage() { }
    }
}
