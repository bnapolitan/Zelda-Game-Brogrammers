using Microsoft.Xna.Framework;

namespace Project3902
{
    class BoomerangWeapon : BasePlayerProjectile
    {
        private readonly float initialSpeed = 300f;
        private readonly float maxSpeed = 1000f;
        private Vector2 startingPos;
        private readonly float maxDistance = 300f;
        private bool turned = false;

        public BoomerangWeapon()
        {
            Sprite = WeaponFactory.Instance.CreateBoomerangSprite(this);
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

            if ((distTraveled > maxDistance))
            {
                Position = startingPos + maxDistance * Direction;
                Direction *= -1;
                turned = true;
            }

            if (turned && distTraveled <= 20f)
                Active = false;

            if (Position == startingPos && (distTraveled > 0))
            {
                Active = false;
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
