using Microsoft.Xna.Framework;

namespace Project3902
{
    class LinkLeftItemState : BaseLinkItemState
    {

        public LinkLeftItemState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateLeftItemSprite(link);
        }

        public override void Enter()
        {
            link.FacingDirection = new Vector2(-1, 0);

            base.Enter();
        }

        protected override void EndUse()
        {
            machine.SwitchState(LinkStates.LeftWalk);
        }
    }
}
