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
            BaseSprite thisSprite = LinkFactory.Instance.CreateHorizontalItemSprite(link) as BaseSprite;
            thisSprite.Flip = SpriteEffects.FlipHorizontally;

            Sprite = thisSprite;
        }

        protected override void EndUse()
        {
            machine.SwitchState(LinkStates.LeftWalk);
        }
    }
}
