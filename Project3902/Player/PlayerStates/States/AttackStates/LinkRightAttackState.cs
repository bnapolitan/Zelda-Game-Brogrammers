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

        protected override void EndAttack()
        {
            machine.SwitchState(LinkStates.RightWalk);
        }
    }
}
