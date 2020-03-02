using Microsoft.Xna.Framework;

namespace Project3902
{
    class LinkLeftWalkState : BaseLinkWalkState
    {

        public LinkLeftWalkState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateLeftWalkSprite(link);
        }

        public override void MoveLeft()
        {
            velocity = new Vector2(-link.MovementSpeed, 0);
            link.FacingDirection = new Vector2(-1, 0);
        }

        public override void Attack()
        {
            machine.SwitchState(LinkStates.LeftAttack);
        }

        public override void UseItem()
        {
            machine.SwitchState(LinkStates.LeftItem);
        }
    }
}
