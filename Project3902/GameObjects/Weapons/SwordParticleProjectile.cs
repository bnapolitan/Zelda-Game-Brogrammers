using Microsoft.Xna.Framework;

namespace Project3902
{
    class SwordParticleProjectile : BasePlayerProjectile
    {
        private readonly float speed = 400f;
        private float flightTime = 0;
        private readonly float maxFlightTime = .3f;
        
        public SwordParticleProjectile()
        {
            var collider = new Collider(this, new Rectangle(0, 0, 0, 0));
            Collider = collider;
        }
        public override void Launch(Vector2 position, Vector2 direction)
        {
            base.Launch(position, direction);

            Sprite = WeaponFactory.Instance.CreateSwordParticleSprite(this, direction);
            var rect = new Rectangle(0, 0, (int)Sprite.Scale.X * (int)Sprite.Size.X, (int)Sprite.Scale.Y * (int)Sprite.Size.Y);
            var collider = new Collider(this, rect);
            Collider = collider;
            Speed = speed;
            flightTime = 0;
            CollisionHandler.Instance.RegisterCollidable(this, Layer.Projectile);
        }

        public override void OnCollide(Collider other)
        {
            if (other.GameObject is IEnemy)
            {
                Deactivate();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Collider.AlignHitbox();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            flightTime += elapsed;
            if (flightTime > maxFlightTime)
                Deactivate();

            Position += Speed * Direction * elapsed;
        }

        private void Deactivate()
        {
            Active = false;
            CollisionHandler.Instance.RemoveCollidable(this);
        }
    }
}
