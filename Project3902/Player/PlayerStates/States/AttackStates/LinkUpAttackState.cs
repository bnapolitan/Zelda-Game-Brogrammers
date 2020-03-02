using Microsoft.Xna.Framework;

namespace Project3902
{
    class LinkUpAttackState : BaseLinkAttackState
    {
        public LinkUpAttackState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateUpAttackSprite(link);
        }

        public override void Enter()
        {
            direction = new Vector2(0, -1);

            base.Enter();
        }

        protected override void EndAttack()
        {
            machine.SwitchState(LinkStates.UpWalk);
        }
    }
}
