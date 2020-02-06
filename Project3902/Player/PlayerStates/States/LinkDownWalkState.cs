using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkDownWalkState : BaseLinkWalkState
    {
        public LinkDownWalkState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            stateSprite = LinkFactory.Instance.CreateDownwardsWalkSprite(link);
        }
        
        public override void MoveDown()
        {
            velocity = new Vector2(0, link.MovementSpeed);
        }
    }
}
