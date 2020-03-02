using Microsoft.Xna.Framework;

namespace Project3902
{
    class LinkDownItemState : BaseLinkItemState
    {

        public LinkDownItemState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateDownItemSprite(link);
        }

        public override void Enter()
        {
            link.FacingDirection = new Vector2(0, 1);

            base.Enter();
        }

        protected override void EndUse()
        {
            machine.SwitchState(LinkStates.DownWalk);
        }
    }
}
