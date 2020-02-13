using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class SwordProjectile : IProjectile
    {
        public Vector2 Direction { get; set; }
        public float Speed { get; set; } = 600f;
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Rectangle Collider { get; set; }

        private float flightTime = 0;
        private float maxFlightTime = .4f;

        public SwordProjectile()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Active)
                return;

            Sprite.Draw(spriteBatch);
        }

        public void Launch(Vector2 position, Vector2 direction)
        {
            Sprite = WeaponFactory.Instance.CreateSwordProjectileSprite(this, direction);

            Position = position;
            Direction = direction;

            flightTime = 0;

            Active = true;
        }

        public void OnCollide() { }

        public void Update(GameTime gameTime)
        {
            if (!Active)
                return;

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Sprite.Update(gameTime);

            flightTime += elapsed;
            if (flightTime > maxFlightTime)
                Active = false;

            Position += Speed * Direction * elapsed;
        }
    }
}
