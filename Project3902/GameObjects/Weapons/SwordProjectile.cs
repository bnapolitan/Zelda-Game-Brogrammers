using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class SwordProjectile : BasePlayerProjectile
    {
        private readonly float speed = 600f;

        private IProjectile upLeftParticle;
        private IProjectile upRightParticle;
        private IProjectile downLeftParticle;
        private IProjectile downRightParticle;

        public SwordProjectile()
        {
            Sprite = WeaponFactory.Instance.CreateSwordProjectileSprite(this, Direction);
            upLeftParticle = WeaponFactory.Instance.CreateSwordParticle();
            upRightParticle = WeaponFactory.Instance.CreateSwordParticle();
            downLeftParticle = WeaponFactory.Instance.CreateSwordParticle();
            downRightParticle = WeaponFactory.Instance.CreateSwordParticle();
        }

        public override void Launch(Vector2 position, Vector2 direction)
        {
            base.Launch(position, direction);

            Sprite = WeaponFactory.Instance.CreateSwordProjectileSprite(this, direction);
            var rect = new Rectangle(0, 0, (int)Sprite.Scale.X *(int) Sprite.Size.X, (int)Sprite.Scale.Y * (int)Sprite.Size.Y);
            var collider = new Collider(this, rect);
            Collider = collider;
            Speed = speed;
            Active = true;
            CollisionHandler.Instance.RegisterCollidable(this, Layer.Projectile);
        }

        public override void OnCollide(Collider other)
        {
            if(other.GameObject is IEnemy)
            {
                Explode();
                Deactivate();
            }
        }

        public override void Update(GameTime gameTime)
        {
            upLeftParticle.Update(gameTime);
            upRightParticle.Update(gameTime);
            downLeftParticle.Update(gameTime);
            downRightParticle.Update(gameTime);

            if (!Active)
                return;

            base.Update(gameTime);
            Collider.AlignHitbox();
            
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Position.X > 924 || Position.X < 100 || Position.Y > 672 || Position.Y < HUDFactory.Instance.HUDHeight + 50)
            {
                Explode();
                Deactivate();
            }

            Position += Speed * Direction * elapsed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            upLeftParticle.Draw(spriteBatch);
            upRightParticle.Draw(spriteBatch);
            downLeftParticle.Draw(spriteBatch);
            downRightParticle.Draw(spriteBatch);
        }

        public bool CanShoot()
        {
            return !Active && !upLeftParticle.Active && !upRightParticle.Active && !downLeftParticle.Active && !downRightParticle.Active;
        }

        private void Explode()
        {
            upLeftParticle.Launch(Position, new Vector2(-1, -1));
            upRightParticle.Launch(Position, new Vector2(1, -1));
            downLeftParticle.Launch(Position, new Vector2(-1, 1));
            downRightParticle.Launch(Position, new Vector2(1, 1));
        }

        private void Deactivate()
        {
            Active = false;
            CollisionHandler.Instance.RemoveCollidable(this);
        }
    }
}
