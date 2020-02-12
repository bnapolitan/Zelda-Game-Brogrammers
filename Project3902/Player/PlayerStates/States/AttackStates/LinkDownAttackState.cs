using Microsoft.Xna.Framework;
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

        public override void Enter()
        {
            direction = new Vector2(0, 1);

            base.Enter();
        }

        protected override void EndAttack()
        {
            machine.SwitchState(LinkStates.DownWalk);
        }
    }
}
