﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;

namespace Project3902
{
    abstract class BaseLinkState : ILinkState
    {
        protected LinkStateMachine machine;
        protected Link link;

        public ISprite Sprite { get; set; }
        public Collider Collider { get => link.Collider; set { } }

        public BaseLinkState(Link link, LinkStateMachine machine)
        {
            this.link = link;
            this.machine = machine;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {

        }

        public abstract void MoveDown();
        public abstract void MoveLeft();
        public abstract void MoveRight();
        public abstract void MoveUp();

        public void TakeDamage(float damage)
        {
            if (!link.Damaged)
            {
                link.Health -= damage;
                LinkFactory.Instance.CreateDamagedLink();
            }
        }

        public abstract void Attack();

        public abstract void Update(GameTime gameTime);

        public abstract void UseItem();

        public virtual void OnCollide(Collider other)
        {
            if (other.GameObject is IInteractiveEnvironmentObject)
            {
                MoveOutOfWall(other);
            }
            else if (other.GameObject is IEnemy)
            {
                TakeDamage((other.GameObject as IEnemy).Damage);
            }
            else if(other.GameObject is IItem)
            {
                CollisionHandler.Instance.RemoveCollidable(other.GameObject as ICollidable);
            }
        }

        private void MoveOutOfWall(Collider other)
        {
            var unitDirection = link.Position - link.PreviousPosition;
            unitDirection.Normalize();

            var hitboxSize = link.Collider.Hitbox.Size;
            var offset = link.Collider.Offset;

            var testRect = new Rectangle((link.PreviousPosition + offset).ToPoint(), hitboxSize);

            while (!other.Intersects(testRect))
            {
                testRect.Location += unitDirection.ToPoint();
            }

            testRect.Location -= unitDirection.ToPoint();

            link.Position = testRect.Location.ToVector2() - offset;
        }
    }
}
