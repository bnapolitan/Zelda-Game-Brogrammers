using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkStateMachine : IStateMachine<LinkStates>, IDrawable, ILinkActions
    {
        private Dictionary<LinkStates, ILinkState> states;
        private Link link;

        private ILinkState currentState;

        public ISprite Sprite { get => currentState.Sprite; set { } }
        public LinkStates CurrentStateEnum { get; private set; }

        public LinkStateMachine(Link link)
        {
            this.link = link;

            states = new Dictionary<LinkStates, ILinkState>
            {
                { LinkStates.LeftWalk, new LinkLeftWalkState(link, this) },
                { LinkStates.UpWalk, new LinkUpWalkState(link, this) },
                { LinkStates.DownWalk, new LinkDownWalkState(link, this) },
                { LinkStates.RightWalk, new LinkRightWalkState(link, this) },
                { LinkStates.UpAttack, new LinkUpAttackState(link, this) },
                { LinkStates.DownAttack, new LinkDownAttackState(link, this) },
                { LinkStates.RightAttack, new LinkRightAttackState(link, this) },
                { LinkStates.LeftAttack, new LinkLeftAttackState(link, this) },
                { LinkStates.UpItem, new LinkUpItemState(link, this) },
                { LinkStates.DownItem, new LinkDownItemState(link, this) },
                { LinkStates.RightItem, new LinkRightItemState(link, this) },
                { LinkStates.LeftItem, new LinkLeftItemState(link, this) }
            };

            // Instead of having to check if the currentState is null in SwitchState()
            currentState = states[LinkStates.RightWalk];
            currentState.Enter();
        }

        public void SwitchState(LinkStates state)
        {
            currentState.Exit();
            currentState = states[state];
            CurrentStateEnum = state;
            currentState.Enter();
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        public void TakeDamage(float damage)
        {
            currentState.TakeDamage(damage);
        }

        public void MoveLeft()
        {
            currentState.MoveLeft();
        }
        public void MoveRight()
        {
            currentState.MoveRight();
        }
        public void MoveDown()
        {
            currentState.MoveDown();
        }
        public void MoveUp()
        {
            currentState.MoveUp();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch);
        }

        public void Attack()
        {
            currentState.Attack();
        }

        public void UseItem()
        {
            currentState.UseItem();
        }
    }
}
