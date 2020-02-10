using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkRightItemState : BaseLinkItemState
    {

        public LinkRightItemState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            stateSprite = LinkFactory.Instance.CreateHorizontalItemSprite(link);
        }

        protected override void EndUse()
        {
            machine.SwitchState(LinkStates.RightWalk);
        }
    }
}
