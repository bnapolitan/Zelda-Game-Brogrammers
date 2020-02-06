using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class Link : ICharacter
    {
        public float Health { get; set; }
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Rectangle Collider { get; set; }

        public float MovementSpeed { get; set; } = 200f;

        private LinkStateMachine machine;

        private KeyboardController controller;

        public Link(Vector2 position)
        {
            Position = position;


            machine = new LinkStateMachine(this);

            controller = new KeyboardController();
            controller.RegisterCommand(Keys.Up, new LinkMoveUpCommand(this));
            controller.RegisterCommand(Keys.Down, new LinkMoveDownCommand(this));
            controller.RegisterCommand(Keys.Left, new LinkMoveLeftCommand(this));
            controller.RegisterCommand(Keys.Right, new LinkMoveRightCommand(this));

            Collider = new Rectangle(Position.ToPoint(), (new Point(16, 16)) * Sprite.Scale.ToPoint());
        }

        public void Update(GameTime gameTime)
        {
            controller.Update();
            machine.Update(gameTime);
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

        public void OnCollide()
        {
        }
    }
}
