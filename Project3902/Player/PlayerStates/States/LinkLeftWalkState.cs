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

        private BaseSprite thisSprite;

        public LinkLeftWalkState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            thisSprite = LinkFactory.Instance.CreateHorizontalWalkSprite(link) as BaseSprite;
            thisSprite.Flip = SpriteEffects.FlipHorizontally;

            stateSprite = thisSprite;
        }

        public override void MoveLeft()
        {
            velocity = new Vector2(-link.MovementSpeed, 0);
        }
    }
}
