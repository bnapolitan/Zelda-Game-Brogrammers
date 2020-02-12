﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkUpItemState : BaseLinkItemState
    {

        public LinkUpItemState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateUpItemSprite(link);
        }

        public override void Enter()
        {
            direction = new Vector2(0, -1);

            base.Enter();
        }
        protected override void EndUse()
        {
            machine.SwitchState(LinkStates.UpWalk);
        }
    }
}
