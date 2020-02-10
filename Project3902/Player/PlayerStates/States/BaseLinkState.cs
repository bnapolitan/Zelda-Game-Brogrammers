using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    abstract class BaseLinkState : ILinkState
    {
        protected ISprite stateSprite;
        protected LinkStateMachine machine;
        protected Link link;

        public ISprite Sprite { get => stateSprite; set => stateSprite = value; }


        public BaseLinkState(Link link, LinkStateMachine machine)
        {
            this.link = link;
            this.machine = machine;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            stateSprite.Draw(spriteBatch);
        }

        public virtual void Enter()
        {
            link.Sprite = stateSprite;
        }

        public virtual void Exit()
        {

        }

        public abstract void MoveDown();
        public abstract void MoveLeft();
        public abstract void MoveRight();
        public abstract void MoveUp();
        public abstract void TakeDamage(float damage);
        public abstract void Attack();

        public virtual void Update(GameTime gameTime)
        {
            stateSprite.Update(gameTime);
        }

        public abstract void UseItem();
    }
}
