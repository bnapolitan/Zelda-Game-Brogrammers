using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects.EnemyProjectiles
{
    class Boomerang : IProjectile
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Rectangle Collider { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }

        private float maxSpeed = 1000f;
        private float minSpeed = 500f;
        private float distance = 500;
        private Vector2 relPos = new Vector2(0, 0);
        private bool turned = false;

        public Boomerang(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Direction = initDirection;
            Speed = moveSpeed;
            Active = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!Active)
            {
                return;
            }

            Sprite.Draw(spriteBatch);
        }

        public void OnCollide()
        {

        }

        public void Update(GameTime gameTime)
        {
            if (!Active)
                return;

            Sprite.Update(gameTime);

            float distTraveled = relPos.Length();

            Speed = (distance - distTraveled) / distance * maxSpeed;
            if (Speed < minSpeed)
                Speed = minSpeed;

            if (distTraveled > distance)
            {
                Direction *= -1;
                turned = true;
            }

            if (turned && distTraveled <= 20f)
                Active = false;

            Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            relPos += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Launch(Vector2 position, Vector2 direction)
        {
            Position = position;
            Direction = direction;
            Active = true;
        }
    }
}