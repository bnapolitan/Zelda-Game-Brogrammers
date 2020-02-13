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
            Sprite = LinkFactory.Instance.CreateLeftItemSprite(link);
        }

        public override void Enter()
        {
            direction = new Vector2(-1, 0);

<<<<<<< HEAD
            Sprite = thisSprite;
=======
            base.Enter();
>>>>>>> 95d9c339c8a72c1ded13f19176bc635ef4bcf063
        }

        protected override void EndUse()
        {
            machine.SwitchState(LinkStates.LeftWalk);
        }
    }
}
