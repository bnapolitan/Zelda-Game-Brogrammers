using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkDownAttackState : BaseLinkAttackState
    {
        public LinkDownAttackState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateDownAttackSprite(link);
        }

        protected override void EndAttack()
        {
            machine.SwitchState(LinkStates.DownWalk);
        }
    }
}
