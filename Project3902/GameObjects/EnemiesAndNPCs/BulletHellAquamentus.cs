﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects.EnemyProjectiles;
using Project3902.ObjectManagement;
using System;

namespace Project3902.GameObjects.EnemiesAndNPCs
{
    class BulletHellAquamentus : ProjectileLaunchingEnemy
    {
        public FinalGame Game { get; }


        private readonly int framesBeforeAttack = 230;
        private int currentFrame = 0;
        private Fireball fireball;
        private Fireball fireball2;
        private Fireball fireball3;
        private readonly int fireballDistance = 800;
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

            if(isShooting)
            {
                fireball.Deactivate();
                fireball.Deactivate();
                fireball.Deactivate();
            }

            fireball = WeaponFactory.Instance.CreateFireballProjectile(Position, fireball1Movement) as Fireball;
            fireball2 = WeaponFactory.Instance.CreateFireballProjectile(Position, new Vector2(fireball1Movement.X, (float)Math.Sin(angle + .524))) as Fireball;
            fireball3 = WeaponFactory.Instance.CreateFireballProjectile(Position, new Vector2(fireball1Movement.X, (float)Math.Sin(angle - .524))) as Fireball;

            fireball.distance = fireballDistance;
            fireball2.distance = fireballDistance;
            fireball3.distance = fireballDistance;
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

        public override void DespawnProjectile()
        {
            if (hasShot)
            {
                (fireball as Fireball).Deactivate();
                (fireball2 as Fireball).Deactivate();
                (fireball3 as Fireball).Deactivate();
            }
        }

        public override void OnCollide(Collider other) {
            base.OnCollide(other);
        }

        public override void TakeDamage() { }
    }
}
