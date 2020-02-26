using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects.EnemyProjectiles
{
    class Fireball : IProjectile
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public Collider Collider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private float distance = 500;
        private Vector2 relPos = new Vector2(0, 0);

        public Fireball(Vector2 pos, float moveSpeed, Vector2 initDirection)
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
            {
                return;
            }

            Position += Direction * Speed;
            relPos += Direction * Speed;
            if (relPos.Length() >= distance)
            {
                Active = false;
            }
            Sprite.Update(gameTime);
        }

        public void Launch(Vector2 position, Vector2 direction)
        {
            Position = position;
            Direction = direction;
            Active = true;
        }

        public void OnCollide(Collider other)
        {
            throw new NotImplementedException();
        }
    }
}