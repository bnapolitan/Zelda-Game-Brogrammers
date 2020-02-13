using Microsoft.Xna.Framework;
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
            Sprite = LinkFactory.Instance.CreateUpAttackSprite(link);
<<<<<<< HEAD
=======
        }

        public override void Enter()
        {
            direction = new Vector2(0, -1);

            base.Enter();
>>>>>>> 95d9c339c8a72c1ded13f19176bc635ef4bcf063
        }

        protected override void EndAttack()
        {
            machine.SwitchState(LinkStates.UpWalk);
        }
    }
}
