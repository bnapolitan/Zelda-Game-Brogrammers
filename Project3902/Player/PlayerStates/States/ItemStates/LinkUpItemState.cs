using Microsoft.Xna.Framework;
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
            stateSprite = LinkFactory.Instance.CreateUpItemSprite(link);
        }

        protected override void EndUse()
        {
            machine.SwitchState(LinkStates.UpWalk);
        }
    }
}
