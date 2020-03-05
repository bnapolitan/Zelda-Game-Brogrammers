using Microsoft.Xna.Framework;

namespace Project3902
{
    class LinkLeftAttackState : BaseLinkAttackState
    {
        public LinkLeftAttackState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateLeftAttackSprite(link);
        }

        public override void Enter()
        {
            direction = new Vector2(-1, 0);

            base.Enter();
        }
        protected override void EndAttack()
        {
            base.EndAttack();
            machine.SwitchState(LinkStates.LeftWalk);
        }
    }
}
