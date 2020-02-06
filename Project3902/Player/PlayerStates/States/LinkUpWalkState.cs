using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkUpWalkState : BaseLinkWalkState
    {

        public LinkUpWalkState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            stateSprite = LinkFactory.Instance.CreateUpwardsWalkSprite(link);
        }

        public override void MoveUp()
        {
            velocity = new Vector2(0, -link.MovementSpeed);
        }
    }
}
