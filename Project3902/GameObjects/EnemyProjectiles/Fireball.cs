using Microsoft.Xna.Framework;

namespace Project3902
{
    class Fireball : BasePlayerProjectile
    {
        private readonly float distance = 500f; 
        private Vector2 relPos = new Vector2(0, 0);
        public Fireball()
        {
            Sprite = WeaponFactory.Instance.CreateFireballSprite(this);
        }

        public override void Launch(Vector2 position, Vector2 direction)
        {
            base.Launch(position, direction);

            Sprite = WeaponFactory.Instance.CreateFireballSprite(this);
            var rect = new Rectangle(0, 0, (int)Sprite.Scale.X * (int)Sprite.Size.X, (int)Sprite.Scale.Y * (int)Sprite.Size.Y);
            var collider = new Collider(this, rect);
            Collider = collider;
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

            if (!Active)
            {
                return;
            }
            base.Update(gameTime);
            Collider.AlignHitbox();
            Position += Direction * Speed;
            relPos += Direction * Speed;
            if (relPos.Length() >= distance)
            {
                Active = false;
            }

        }

        private void Deactivate()
        {
            Active = false;
            CollisionHandler.Instance.RemoveCollidable(this);
        }
    }
}
