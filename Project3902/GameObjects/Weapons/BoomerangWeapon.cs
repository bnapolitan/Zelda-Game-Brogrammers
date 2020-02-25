using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class BoomerangWeapon : BaseProjectile
    {
        private float initialSpeed = 300f;
        private float maxSpeed = 1000f;
        private Vector2 startingPos;
        private float maxDistance = 300f;
        private bool turned = false;

        public BoomerangWeapon()
        {
            Sprite = WeaponFactory.Instance.CreateBoomerangSprite(this);
        }

        public void OnCollide() { }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float distTraveled = (Position - startingPos).Length();

            Speed = (maxDistance - distTraveled) / maxDistance * maxSpeed;
            if (Speed < maxSpeed * .5f)
                Speed = maxSpeed * .5f;

            if (distTraveled > maxDistance)
            {
                Position = startingPos + maxDistance * Direction;
                Direction *= -1;
                turned = true;
            }

            if (turned && distTraveled <= 20f)
                Active = false;

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
