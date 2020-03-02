using Microsoft.Xna.Framework;

namespace Project3902
{
    class LinkDownAttackState : BaseLinkAttackState
    {
        public LinkDownAttackState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateDownAttackSprite(link);
        }

        public override void Enter()
        {
            direction = new Vector2(0, 1);

            base.Enter();
        }

        protected override void EndAttack()
        {
            machine.SwitchState(LinkStates.DownWalk);
        }
    }
}
