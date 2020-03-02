using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class SwordProjectile : BaseProjectile
    {
        private float speed = 600f;
        private float flightTime = 0;
        private float maxFlightTime = .4f;

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

        public void OnCollide() { }

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
