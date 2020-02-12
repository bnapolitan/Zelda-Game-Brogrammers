using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class DamagedLink : ILink
    {

        private ILink decoratedLink;

        private float timeSinceDamage = 0f;
        private float damageTime = 2f;

        private float flickerTime = .25f;
        private float timeSinceFlicker = 0f;

        private Color damageColor = Color.Maroon;
        private Color originalColor = Color.White;
        private Color tint;

        private Sprint2 game;

        public float Health { get => decoratedLink.Health; set => decoratedLink.Health = value; }
        public Vector2 Position { get => decoratedLink.Position; set => decoratedLink.Position = value; }
        public ISprite Sprite { get => decoratedLink.Sprite; set => decoratedLink.Sprite = value; }
        public bool Active { get => decoratedLink.Active; set => decoratedLink.Active = value; }
        public Rectangle Collider { get => decoratedLink.Collider; set => decoratedLink.Collider = value; }
        public float MaxHealth { get => decoratedLink.MaxHealth; set => decoratedLink.MaxHealth = value; }

        public DamagedLink(ILink decoratedLink, Sprint2 game)
        {
            this.decoratedLink = decoratedLink;
            this.game = game;

            tint = damageColor;
        }

        public void RemoveDecorator()
        {
            game.Link = decoratedLink;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            (Sprite as BaseSprite).DrawTinted(spriteBatch, tint);
        }

        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSinceDamage += elapsed;
            timeSinceFlicker += elapsed;

            if (timeSinceDamage >= damageTime)
                RemoveDecorator();

            if (timeSinceFlicker >= flickerTime)
            {
                timeSinceFlicker = 0f;

                if (tint == damageColor)
                    tint = originalColor;
                else
                    tint = damageColor;
            }

            decoratedLink.Update(gameTime);
        }

        public void MoveDown()
        {
            decoratedLink.MoveDown();
        }

        public void MoveLeft()
        {
            decoratedLink.MoveLeft();
        }

        public void MoveRight()
        {
            decoratedLink.MoveRight();
        }

        public void MoveUp()
        {
            decoratedLink.MoveUp();
        }

        public void OnCollide()
        {
            decoratedLink.OnCollide();
        }

        public void TakeDamage(float damage)
        {
            // Does not take damage while damaged.
        }

        public void Attack()
        {
            decoratedLink.Attack();
        }

        public void UseItem()
        {
            decoratedLink.UseItem();
        }
    }
}
