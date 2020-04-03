using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class Link : ILink
    {
        public float Health { get; set; }
        public float MaxHealth { get; set; }

        public bool Damaged { get; set; } = false;

        private Vector2 position;
        public Vector2 PreviousPosition { get; set; }
        public Vector2 Position { 
            get 
            {
                return position;
            }
            set 
            {
                PreviousPosition = position;
                position = value;
                Collider.AlignHitbox();
            }
        }

        public ISprite Sprite { get => machine.Sprite; set { } }
        public bool Active { get; set; } = true;
        public float MovementSpeed { get; set; } = 200f;

        public IProjectile CurrentWeapon { get; set; }
        public IProjectile SwordProjectile { get; set; }
        public IProjectile Sword { get; set; }

        public int KeyCount { get; set; }
        public Collider Collider { get; set; }
        public Vector2 FacingDirection { get; set; } = new Vector2(1, 0);

        private readonly LinkStateMachine machine;

        public Link(Vector2 position)
        {
            Health = 5;
            MaxHealth = Health;

            machine = new LinkStateMachine(this);

            Collider = new Collider(this, new Rectangle(new Point(4, 4), new Point(16, 16) * Sprite.Scale.ToPoint()));

            CurrentWeapon = WeaponFactory.Instance.CreateBlueCandleProjectile();
            SwordProjectile = WeaponFactory.Instance.CreateSwordProjectile();
            Sword = WeaponFactory.Instance.CreateSword();

            Position = position;
        }

        public void Update(GameTime gameTime)
        {
            CurrentWeapon.Update(gameTime);
            SwordProjectile.Update(gameTime);
            Sword.Update(gameTime);
            machine.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Collider.Draw(spriteBatch);

            machine.Draw(spriteBatch);

            CurrentWeapon.Draw(spriteBatch);
            SwordProjectile.Draw(spriteBatch);
            Sword.Draw(spriteBatch);
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
            machine.OnCollide(other);
        }
    }
}
