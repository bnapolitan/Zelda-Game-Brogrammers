﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.ObjectManagement;
using System;

namespace Project3902.GameObjects.Enemies_and_NPCs
{
    class Aquamentus : ProjectileLaunchingEnemy
    {
        public Sprint2 Game { get; }
        private float distance = 100;
        private Vector2 relPos = new Vector2(0, 0);
        private int framesBeforeAttack = 120;
        private int currentFrame = 0;
        private IProjectile fireball;
        private IProjectile fireball2;
        private IProjectile fireball3;
        private bool isShooting = false;

        public Aquamentus(Vector2 pos, float moveSpeed, Vector2 initDirection, Sprint2 game) : base(pos, moveSpeed, initDirection)
        {
            this.Game = game;
            Sprite = EnemyFactory.Instance.CreateAquamentusSprite(this);
        }

        public override void Attack()
        {
            Vector2 fireball1Movement = Game.Link.Position - Position;
            fireball1Movement.Normalize();

            var angle = Math.Atan2(fireball1Movement.Y, fireball1Movement.X);

            // TODO : Move these into Game object lists

            fireball = WeaponFactory.Instance.CreateFireballProjectile(Position, fireball1Movement);
            fireball2 = WeaponFactory.Instance.CreateFireballProjectile(Position, new Vector2((float)Math.Cos(angle + .524), (float)Math.Sin(angle + .524)));
            fireball3 = WeaponFactory.Instance.CreateFireballProjectile(Position, new Vector2((float)Math.Cos(angle - .524), (float)Math.Sin(angle - .524)));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isShooting)
            {
                fireball.Draw(spriteBatch);
                fireball2.Draw(spriteBatch);
                fireball3.Draw(spriteBatch);
            }

            Sprite.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (currentFrame >= framesBeforeAttack)
            {
                this.Attack();
                isShooting = true;
                currentFrame = 0;
            }

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

            currentFrame++;

            if (isShooting)
            {
                fireball.Update(gameTime);
                fireball2.Update(gameTime);
                fireball3.Update(gameTime);
            }

            Sprite.Update(gameTime);
        }
    }
}