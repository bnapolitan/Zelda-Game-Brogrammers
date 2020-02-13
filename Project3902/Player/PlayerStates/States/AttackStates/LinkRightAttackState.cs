using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkRightAttackState : BaseLinkAttackState
    {
        public LinkRightAttackState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateRightAttackSprite(link);
        }

        public override void Enter()
        {
            direction = new Vector2(1, 0);

            base.Enter();
        }

        protected override void EndAttack()
        {
            machine.SwitchState(LinkStates.RightWalk);
        }
    }
}
