﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkRightWalkState : BaseLinkWalkState
    {
        public LinkRightWalkState(Link link, LinkStateMachine machine)
            : base(link, machine) 
        {
            Sprite = LinkFactory.Instance.CreateRightWalkSprite(link);
        }

        public override void MoveRight()
        {
            velocity = new Vector2(link.MovementSpeed, 0);
        }

        public override void Attack()
        {
            machine.SwitchState(LinkStates.RightAttack);
        }

        public override void UseItem()
        {
            machine.SwitchState(LinkStates.RightItem);
        }
    }
}
