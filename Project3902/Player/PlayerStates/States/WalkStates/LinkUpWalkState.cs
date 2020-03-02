using Microsoft.Xna.Framework;

namespace Project3902
{
    class LinkUpWalkState : BaseLinkWalkState
    {

        public LinkUpWalkState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateUpWalkSprite(link);
        }

        public override void MoveUp()
        {
            velocity = new Vector2(0, -link.MovementSpeed);
            link.FacingDirection = new Vector2(0, -1);
        }

        public override void Attack()
        {
            machine.SwitchState(LinkStates.UpAttack);
        }

        public override void UseItem()
        {
            machine.SwitchState(LinkStates.UpItem);
        }
    }
}
