﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;
using System;

namespace Project3902
{
    abstract class BaseEnemy : IEnemy
    {
        public float Health { get; set; }
        public Vector2 Direction { get; set; }
        public float MoveSpeed { get; set; }
        private Color tint = Color.White;
        public Vector2 PreviousPosition { get; set; }
        private Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                PreviousPosition = position;
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
        protected bool attackedRecent = false;
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
                if (other.GameObject is IProjectile)
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
                    (other.GameObject as IProjectile).OnCollide(Collider);
                    Position = new Vector2(Position.X + move.X, Position.Y + move.Y);
                    Collider.AlignHitbox();
                }
            }
            if(other.GameObject is IInteractiveEnvironmentObject) 
            {
                MoveOutOfWall(other);
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
                    tint = Color.White;
                }
            }
        }

        private void MoveOutOfWall(Collider other)
        {
            var unitDirection = Position - PreviousPosition;
            unitDirection.Normalize();

            var hitboxSize = Collider.Hitbox.Size;
            var offset = Collider.Offset;

            var testRect = new Rectangle((PreviousPosition + offset).ToPoint(), hitboxSize);

            while (!other.Intersects(testRect))
            {
                testRect.Location += unitDirection.ToPoint();
            }

            testRect.Location -= unitDirection.ToPoint();

            Position = testRect.Location.ToVector2() - offset;
        }
    }
}
