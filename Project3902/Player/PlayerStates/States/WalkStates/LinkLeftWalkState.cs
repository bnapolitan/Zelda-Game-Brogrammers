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
            BaseSprite thisSprite = LinkFactory.Instance.CreateHorizontalWalkSprite(link) as BaseSprite;
            thisSprite.Flip = SpriteEffects.FlipHorizontally;

            Sprite = thisSprite;
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
