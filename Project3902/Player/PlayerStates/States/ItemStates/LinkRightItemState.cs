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
<<<<<<< HEAD
            Sprite = LinkFactory.Instance.CreateHorizontalItemSprite(link);
=======
            Sprite = LinkFactory.Instance.CreateRightItemSprite(link);
        }

        public override void Enter()
        {
            direction = new Vector2(1, 0);

            base.Enter();
>>>>>>> 95d9c339c8a72c1ded13f19176bc635ef4bcf063
        }

        protected override void EndUse()
        {
            machine.SwitchState(LinkStates.RightWalk);
        }
    }
}
