using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkLeftItemState : BaseLinkItemState
    {

        public LinkLeftItemState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateLeftItemSprite(link);
        }

        public override void Enter()
        {
            direction = new Vector2(-1, 0);

            base.Enter();
        }

        protected override void EndUse()
        {
            machine.SwitchState(LinkStates.LeftWalk);
        }
    }
}
