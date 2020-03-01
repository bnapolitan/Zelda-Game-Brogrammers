using Microsoft.Xna.Framework;

namespace Project3902
{
    class LinkDownWalkState : BaseLinkWalkState
    {
        public LinkDownWalkState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateDownWalkSprite(link);
        }
        
        public override void MoveDown()
        {
            velocity = new Vector2(0, link.MovementSpeed);
            link.FacingDirection = new Vector2(0, 1);
        }

        public override void Attack()
        {
            machine.SwitchState(LinkStates.DownAttack);
        }

        public override void UseItem()
        {
            machine.SwitchState(LinkStates.DownItem);
        }
    }
}
