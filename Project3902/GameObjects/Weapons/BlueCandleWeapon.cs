using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class BlueCandleWeapon : BaseProjectile
    {
        private float activeTime = 0;
        private float maxActiveTime = 1f;
        private float startSpeed = 1000f;

        public BlueCandleWeapon()
        {
            Sprite = WeaponFactory.Instance.CreateBlueCandleFireSprite(this);
        }

        public void OnCollide() { }

        public override void Launch(Vector2 position, Vector2 direction)
        {
            base.Launch(position, direction);

            Speed = startSpeed;
            activeTime = 0;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Collider.AlignHitbox();
            float elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;

            Speed *= .9f;

            activeTime += elapsed;
            if (activeTime >= maxActiveTime)
                Active = false;

            Position += Speed * Direction * elapsed;
        }
    }
}
