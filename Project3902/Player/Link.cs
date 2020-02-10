﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class Link : ILink
    {
        public float Health { get; set; }
        public Vector2 Position { get; set; }

        // Need to refactor how the Sprite is handled here and down in the states.
        public ISprite Sprite { get => machine.Sprite; set { } }
        public bool Active { get; set; }

        private Rectangle collider;
        public Rectangle Collider { get => collider; set => collider = value; }

        public float MovementSpeed { get; set; } = 200f;

        private Sprint2 game;

        private LinkStateMachine machine;

        private KeyboardController controller;

        public Link(Vector2 position, Sprint2 game)
        {
            Position = position;
            this.game = game;

            machine = new LinkStateMachine(this);

            controller = LinkFactory.Instance.CreateLinkController(this, game);

            collider = new Rectangle(Position.ToPoint(), new Point(16, 16) * Sprite.Scale.ToPoint());
        }

        public void Update(GameTime gameTime)
        {
            controller.Update();
            machine.Update(gameTime);

            collider.Location = Position.ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            machine.Draw(spriteBatch);
        }

        public void TakeDamage(float damage)
        {
            machine.TakeDamage(damage);
        }

        public void MoveUp()
        {
            machine.MoveUp();
        }

        public void MoveDown()
        {
            machine.MoveDown();
        }

        public void MoveLeft()
        {
            machine.MoveLeft();
        }

        public void MoveRight()
        {
            machine.MoveRight();
        }

        public void Attack()
        {
            machine.Attack();
        }

        public void OnCollide()
        {
        }

        public void UseItem()
        {
            machine.UseItem();
        }
    }
}
