using Microsoft.Xna.Framework;

namespace Project3902
{
    class SwordProjectile : BasePlayerProjectile
    {
        private readonly float speed = 600f;
        private float flightTime = 0;
        private readonly float maxFlightTime = .4f;

        public SwordProjectile()
        {
            Sprite = WeaponFactory.Instance.CreateSwordProjectileSprite(this, Direction);
        }

        public override void Launch(Vector2 position, Vector2 direction)
        {
            base.Launch(position, direction);

            Sprite = WeaponFactory.Instance.CreateSwordProjectileSprite(this, direction);

            Speed = speed;
            flightTime = 0;
        }

        public override void OnCollide(Collider other)
        {
            if(other.GameObject is IEnemy)
            {
                
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Collider.AlignHitbox();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            flightTime += elapsed;
            if (flightTime > maxFlightTime)
                Active = false;

            Position += Speed * Direction * elapsed;
        }
    }
}
