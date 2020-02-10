using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkUpAttackState : BaseLinkAttackState
    {
        public LinkUpAttackState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            stateSprite = LinkFactory.Instance.CreateUpAttackSprite(link);
        }

        protected override void EndAttack()
        {
            machine.SwitchState(LinkStates.UpWalk);
        }
    }
}
