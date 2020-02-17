using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class BoomerangWeapon : IProjectile
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; } = false;
        public Rectangle Collider { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; } = 300f;

        private float maxSpeed = 1000f;
        private Vector2 startingPos;
        private float maxDistance = 300f;
        private bool turned = false;

        public BoomerangWeapon()
        {
            Sprite = WeaponFactory.Instance.CreateBoomerangSprite(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Active)
                return;

            Sprite.Draw(spriteBatch);
        }

        public void OnCollide() { }

        public void Update(GameTime gameTime)
        {
            if (!Active)
                return;

            Sprite.Update(gameTime);

            // This is a mess.

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

        public void Launch(Vector2 position, Vector2 direction)
        {
            startingPos = position;
            Position = position;
            Direction = direction;

            Active = true;
            turned = false;
        }
    }
}
