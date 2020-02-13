using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    abstract class ProjectileLaunchingEnemy : IEnemy
    {
        public float Health { get; set; }
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Rectangle Collider { get; set; }
        public float MoveSpeed { get; set; }
        public Vector2 Direction { get; set; }

        public ProjectileLaunchingEnemy(Vector2 pos, float moveSpeed, Vector2 initDirection)
        {
            Position = pos;
            Active = true;
            MoveSpeed = moveSpeed;
            Direction = initDirection;
        }

        public void TakeDamage()
        {

        }
        public abstract void Attack();

        public abstract void Draw(SpriteBatch spriteBatch);

        public void OnCollide()
        {

        }

        public abstract void Update(GameTime gameTime);
    }
}
