using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkRightWalkState : BaseLinkWalkState
    {
        public LinkRightWalkState(Link link, LinkStateMachine machine)
            : base(link, machine) 
        {
<<<<<<< HEAD
            Sprite = LinkFactory.Instance.CreateHorizontalWalkSprite(link);
=======
            Sprite = LinkFactory.Instance.CreateRightWalkSprite(link);
>>>>>>> 95d9c339c8a72c1ded13f19176bc635ef4bcf063
        }

        public override void MoveRight()
        {
            velocity = new Vector2(link.MovementSpeed, 0);
        }

        public override void Attack()
        {
            machine.SwitchState(LinkStates.RightAttack);
        }

        public override void UseItem()
        {
            machine.SwitchState(LinkStates.RightItem);
        }
    }
}
