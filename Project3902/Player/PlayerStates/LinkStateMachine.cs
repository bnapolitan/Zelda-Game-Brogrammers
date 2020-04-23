using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project3902
{
    class LinkStateMachine : IStateMachine<LinkStates>, IDrawable, ILinkActions
    {
        private readonly Dictionary<LinkStates, ILinkState> states;

        private ILinkState currentState;

        public ISprite Sprite { get => currentState.Sprite; set { } }
        public LinkStates CurrentStateEnum { get; private set; }

        public LinkStateMachine(Link link)
        {
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
                { LinkStates.LeftItem, new LinkLeftItemState(link, this) },
                { LinkStates.Triforce, new LinkTriforceState(link, this) }
            };

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

        public void OnCollide(Collider other)
        {
            currentState.OnCollide(other);
        }
    }
}
