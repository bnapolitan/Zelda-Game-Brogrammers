using Microsoft.Xna.Framework;

namespace Project3902
{
    class LinkRightItemState : BaseLinkItemState
    {

        public LinkRightItemState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateRightItemSprite(link);
        }

        public override void Enter()
        {
            link.FacingDirection = new Vector2(1, 0);

            base.Enter();
        }

        protected override void EndUse()
        {
            machine.SwitchState(LinkStates.RightWalk);
        }
    }
}
