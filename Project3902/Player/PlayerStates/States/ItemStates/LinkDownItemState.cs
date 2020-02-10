using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkDownItemState : BaseLinkItemState
    {

        public LinkDownItemState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            stateSprite = LinkFactory.Instance.CreateDownItemSprite(link);
        }

        protected override void EndUse()
        {
            machine.SwitchState(LinkStates.DownWalk);
        }
    }
}
