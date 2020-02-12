using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class BlueCandleWeapon : IProjectile
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; } = false;
        public Rectangle Collider { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }

        private float activeTime = 0;
        private float maxActiveTime = 1f;
        private float startSpeed = 1000f;

        public BlueCandleWeapon()
        {
            Sprite = WeaponFactory.Instance.CreateBlueCandleFireSprite(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Active)
                return;

            Sprite.Draw(spriteBatch);
        }

        public void OnCollide() { }

        public void Launch(Vector2 position, Vector2 direction)
        {
            Position = position;
            Direction = direction;
            Speed = startSpeed;

            activeTime = 0;
            Active = true;
        }

        public void Update(GameTime gameTime)
        {
            if (!Active)
                return;

            Sprite.Update(gameTime);

            float elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;

            Speed *= .9f;

            activeTime += elapsed;
            if (activeTime >= maxActiveTime)
                Active = false;

            Position += Speed * Direction * elapsed;
        }
    }
}
