using Microsoft.Xna.Framework;
using Project3902.ObjectManagement;

namespace Project3902
{
    class BoomerangWeapon : BasePlayerProjectile
    {
        private readonly float initialSpeed = 300f;
        private readonly float maxSpeed = 1000f;
        private Vector2 startingPos;
        private readonly float maxDistance = 300f;
        private bool turned = false;

        public ILink Link;

        public BoomerangWeapon()
        {
            Sprite = WeaponFactory.Instance.CreateBoomerangSprite(this);
            SoundHandler.Instance.StopEffectInstance();
            SoundHandler.Instance.PlaySoundEffect("Boomerang");
        }

        public override void OnCollide(Collider other) {
            if(other.GameObject is IEnemy )
            {
                if (!turned)
                {
                    Direction *= -1;
                    turned = true;
                    Position += (Direction * ((Speed / 30) + 3));
                }
            }

            if (turned && other.GameObject is ILink)
            {
                Active = false;
                SoundHandler.Instance.StopEffectInstance(true);
                CollisionHandler.Instance.RemoveCollidable(this);
            }

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Collider.AlignHitbox();
           
            if (!Active)
            {
                return;
            }

            float distTraveled = (Position - startingPos).Length();


            Speed = (maxDistance - distTraveled) / maxDistance * maxSpeed;

            if ((Speed < maxSpeed * .5f))
                Speed = maxSpeed * .5f;

            if (!turned && (distTraveled > maxDistance))
            {
                Position = startingPos + maxDistance * Direction;
                Direction *= -1;
                turned = true;
            }

            if (turned)
            {
                Direction = Link.Position - Position;
                Direction = Vector2.Normalize(Direction);
            }

            Position += Direction * Speed * (float) gameTime.ElapsedGameTime.TotalSeconds;
            
        }

        public override void Launch(Vector2 position, Vector2 direction)
        {
            base.Launch(position, direction);

            startingPos = position;

            Speed = initialSpeed;

            turned = false;
        }
    }
}
