using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;
using Project3902.GameObjects.EnemyProjectiles;
using System;

namespace Project3902
{
    abstract class BaseEnemy : IEnemy
    {
        public float Health { get; set; }
        public Vector2 Direction { get; set; }
        public float MoveSpeed { get; set; }
        private Color tint = Color.White;
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
        public float Damage { get; set; } = 1f;
        private int collisionDelay=20;
        private bool attackedRecent = false;
        public abstract void Attack();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Collider.Draw(spriteBatch);
            (Sprite as AnimatedSprite).DrawTinted(spriteBatch, tint);
            
        }

        public virtual void OnCollide(Collider other)
        {
            if (!attackedRecent)
            {
                if ((other.GameObject is IProjectile) && !(other.GameObject is Boomerang))
                {
                    
                    attackedRecent = true;
                    Health--;
                    tint = Color.Red;
                    Console.WriteLine(Health);
                    if (Health == 0)
                    {
                        Active = false;
                        CollisionHandler.Instance.RemoveCollidable(this);
                    }
                    Vector2 move = (other.GameObject as IProjectile).Direction * 20;
                    (other.GameObject as IProjectile).OnCollide(this.Collider);
                    Position = new Vector2(Position.X + move.X, Position.Y + move.Y);
                    Collider.AlignHitbox();
                }
            }
            if(other.GameObject is IInteractiveEnvironmentObject) 
            {
                Direction=new Vector2(Direction.Y, Direction.X*-1);
            }
        }

        public abstract void TakeDamage();

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
            if (attackedRecent)
            {
                collisionDelay--;
                if (collisionDelay == 0)
                {
                    attackedRecent = false;
                    collisionDelay = 20;
                }
            }
        }
    }
}
