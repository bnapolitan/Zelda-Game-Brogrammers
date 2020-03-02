using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects.Environment;
using System;

namespace Project3902
{
    abstract class BaseEnemy : IEnemy
    {
        public float Health { get; set; }
        public Vector2 Direction { get; set; }
        public float MoveSpeed { get; set; }

        private Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                if (Collider != null)
                    Collider.AlignHitbox();
            }
        }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }
        public Collider Collider { get; set; }

        public abstract void Attack();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Collider.Draw(spriteBatch);
            Sprite.Draw(spriteBatch);
            
        }

        public virtual void OnCollide(Collider other)
        {
            if (other.GameObject is IProjectile) 
            {
                Health--;
                Console.WriteLine(Health);
                if (Health == 0)
                {
                    Active = false;
                }
                Vector2 Move = (other.GameObject as IProjectile).Direction * 40;
                //Position = new Vector2(Position.X +Move.X, Position.Y+Move.Y);
            }
            else if(other.GameObject is BaseEnvironment) 
            {
                Direction=new Vector2(Direction.Y, Direction.X*-1);
            }
        }

        public abstract void TakeDamage();

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
    }
}
