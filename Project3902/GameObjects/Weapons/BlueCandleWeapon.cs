﻿using Microsoft.Xna.Framework;

namespace Project3902
{
    class BlueCandleWeapon : BasePlayerProjectile
    {
        private float activeTime = 0;
        private readonly float maxActiveTime = 1f;
        private readonly float startSpeed = 1000f;

        public BlueCandleWeapon()
        {
            Sprite = WeaponFactory.Instance.CreateBlueCandleFireSprite(this);
        }

        public override void OnCollide(Collider other)
        {
            if(other.GameObject is IEnemy)
            {
            }

        
        }

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
            {
                Active = false;
                CollisionHandler.Instance.RemoveCollidable(this);
            }

            Position += Speed * Direction * elapsed;
        }
    }
}
