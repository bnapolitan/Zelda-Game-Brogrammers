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
    class LinkLeftWalkState : BaseLinkWalkState
    {

        public LinkLeftWalkState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateLeftWalkSprite(link);
        }

        public override void MoveLeft()
        {
            velocity = new Vector2(-link.MovementSpeed, 0);
        }

        public override void Attack()
        {
            machine.SwitchState(LinkStates.LeftAttack);
        }

        public override void UseItem()
        {
            machine.SwitchState(LinkStates.LeftItem);
        }
    }
}
