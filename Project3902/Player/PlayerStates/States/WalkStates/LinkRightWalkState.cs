using Microsoft.Xna.Framework;

namespace Project3902
{
    class LinkRightWalkState : BaseLinkWalkState
    {
        public LinkRightWalkState(Link link, LinkStateMachine machine)
            : base(link, machine) 
        {
            Sprite = LinkFactory.Instance.CreateRightWalkSprite(link);
        }

        public override void MoveRight()
        {
            velocity = new Vector2(link.MovementSpeed, 0);
            link.FacingDirection = new Vector2(1, 0);
        }

        public override void Attack()
        {
            machine.SwitchState(LinkStates.RightAttack);
        }

        public override void UseItem()
        {
            machine.SwitchState(LinkStates.RightItem);
        }
    }
}
