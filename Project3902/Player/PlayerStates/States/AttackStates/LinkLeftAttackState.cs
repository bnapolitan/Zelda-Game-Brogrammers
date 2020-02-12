using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkLeftAttackState : BaseLinkAttackState
    {
        public LinkLeftAttackState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateLeftAttackSprite(link);
        }

        public override void Enter()
        {
            direction = new Vector2(-1, 0);

            base.Enter();
        }
        protected override void EndAttack()
        {
            machine.SwitchState(LinkStates.LeftWalk);
        }
    }
}
