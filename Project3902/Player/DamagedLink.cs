using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class DamagedLink : ILink
    {

        private readonly ILink decoratedLink;

        private float timeSinceDamage = 0f;
        private readonly float damageTime = 2f;

        private readonly float flickerTime = .25f;
        private float timeSinceFlicker = 0f;

        private Color damageColor = Color.Maroon;
        private Color originalColor = Color.White;
        private Color tint;

        private readonly FinalGame game;

        public float MovementSpeed { get => decoratedLink.MovementSpeed; set => decoratedLink.MovementSpeed = value; }
        public float Health { get => decoratedLink.Health; set => decoratedLink.Health = value; }
        public Vector2 Position { get => decoratedLink.Position; set => decoratedLink.Position = value; }
        public ISprite Sprite { get => decoratedLink.Sprite; set => decoratedLink.Sprite = value; }
        public bool Active { get => decoratedLink.Active; set => decoratedLink.Active = value; }
        public float MaxHealth { get => decoratedLink.MaxHealth; set => decoratedLink.MaxHealth = value; }
        public IProjectile CurrentWeapon { get => decoratedLink.CurrentWeapon; set => decoratedLink.CurrentWeapon = value; }
        public IProjectile SwordProjectile { get => decoratedLink.SwordProjectile; set => decoratedLink.SwordProjectile = value; }
        public Collider Collider { get => decoratedLink.Collider; set => decoratedLink.Collider = value; }
        public bool Damaged { get => decoratedLink.Damaged; set => decoratedLink.Damaged = value; }
        public Vector2 FacingDirection { get => decoratedLink.FacingDirection; set => decoratedLink.FacingDirection = value; }
        public IProjectile Sword { get => decoratedLink.Sword; set => decoratedLink.Sword = value; }
        public int CoinCount { get => decoratedLink.CoinCount; set => decoratedLink.CoinCount = value; }
        public int KeyCount { get => decoratedLink.KeyCount; set => decoratedLink.KeyCount = value; }
        public int BombCount { get => decoratedLink.BombCount; set => decoratedLink.BombCount = value; }
        public int BombExplodeTime { get => decoratedLink.BombExplodeTime; set => decoratedLink.BombExplodeTime = value; }

        private readonly Vector2 knockbackDirection;
        private readonly float knockbackSpeed = 700;
        private readonly float knockbackTime = .20f;
        private float timeSinceKnockback = 0f;

        public DamagedLink(ILink decoratedLink, FinalGame game)
        {
            this.decoratedLink = decoratedLink;
            this.game = game;

            Damaged = true;

            tint = damageColor;

            knockbackDirection = -FacingDirection;
        }

        public void RemoveDecorator()
        {
            Damaged = false;
            game.Link = decoratedLink;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Collider.Draw(spriteBatch);
            (Sprite as BaseSprite).DrawTinted(spriteBatch, tint);
            CurrentWeapon.Draw(spriteBatch);
            SwordProjectile.Draw(spriteBatch);
            Sword.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSinceDamage += elapsed;
            timeSinceFlicker += elapsed;
            timeSinceKnockback += elapsed;

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

            if (timeSinceKnockback < knockbackTime)
            {
                Position += knockbackDirection * knockbackSpeed * elapsed;
            }

            decoratedLink.Update(gameTime);
        }

        public void MoveDown()
        {
            if (timeSinceKnockback >= knockbackTime)
                decoratedLink.MoveDown();
        }

        public void MoveLeft()
        {
            if (timeSinceKnockback >= knockbackTime)
                decoratedLink.MoveLeft();
        }

        public void MoveRight()
        {
            if (timeSinceKnockback >= knockbackTime)
                decoratedLink.MoveRight();
        }

        public void MoveUp()
        {
            if (timeSinceKnockback >= knockbackTime)
                decoratedLink.MoveUp();
        }

        public void TakeDamage(float damage)
        {
            decoratedLink.TakeDamage(damage);
        }

        public void Attack()
        {
            decoratedLink.Attack();
        }

        public void UseItem()
        {
            decoratedLink.UseItem();
        }

        public void OnCollide(Collider other)
        {
            decoratedLink.OnCollide(other);
        }
    }
}
