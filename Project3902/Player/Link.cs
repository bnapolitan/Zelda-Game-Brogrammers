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
    class Link : ILink
    {
        public float Health { get; set; }
        public float MaxHealth { get; set; }

        private Vector2 position;

        public Vector2 Position { 
            get 
            {
                return position;
            }
            set 
            {
                position = value;
                Collider.AlignHitbox();
            }
        }

        public ISprite Sprite { get => machine.Sprite; set { } }
        public bool Active { get; set; }

        public float MovementSpeed { get; set; } = 200f;

        // Want this to be an IWeapon, but such an interface wouldn't have much use over IProjectile...
        public IProjectile CurrentWeapon { get; set; }

        public IProjectile SwordProjectile { get; set; }
        public Collider Collider { get; set; }

        private FinalGame game;

        private LinkStateMachine machine;

        private KeyboardController controller;

        public Link(Vector2 position, FinalGame game)
        {
            this.game = game;

            Health = 5;
            MaxHealth = Health;

            machine = new LinkStateMachine(this);

            controller = LinkFactory.Instance.CreateLinkController(this, game);

            Collider = new Collider(this, new Rectangle(new Point(0, 0), new Point(16, 16) * Sprite.Scale.ToPoint()));

            CurrentWeapon = WeaponFactory.Instance.CreateBlueCandleProjectile();
            SwordProjectile = new SwordProjectile(); // Replace with factory method.

            Position = position;
        }

        public void Update(GameTime gameTime)
        {
            controller.Update();
            CurrentWeapon.Update(gameTime);
            SwordProjectile.Update(gameTime);

            machine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Collider.Draw(spriteBatch);
            machine.Draw(spriteBatch);
            CurrentWeapon.Draw(spriteBatch);
            SwordProjectile.Draw(spriteBatch);
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

        public void UseItem()
        {
            machine.UseItem();
        }

        public void OnCollide(Collider other)
        {
            if (other.GameObject is Gel) // Could replace Gel with any enemy type, or even IEnemy
            {
                Console.WriteLine("Link is colliding with an IEnemy: " + other.GameObject.ToString());
                // Example response:
                new LinkTakeDamageCommand(this, game).Execute();
                Position = new Vector2(Position.X - 20, Position.Y);
            }
        }
    }
}
