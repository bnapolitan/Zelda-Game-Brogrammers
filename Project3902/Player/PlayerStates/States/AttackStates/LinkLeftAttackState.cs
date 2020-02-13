using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class LinkLeftAttackState : BaseLinkAttackState
    {
        public LinkLeftAttackState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
<<<<<<< HEAD
            BaseSprite thisSprite = LinkFactory.Instance.CreateLeftAttackSprite(link) as BaseSprite;
            thisSprite.Flip = SpriteEffects.FlipHorizontally;

            Sprite = thisSprite;
=======
            Sprite = LinkFactory.Instance.CreateLeftAttackSprite(link);
>>>>>>> 95d9c339c8a72c1ded13f19176bc635ef4bcf063
        }

        public override void Enter()
        {
            direction = new Vector2(-1, 0);

            base.Enter();
        }
        protected override void EndAttack()
        {
            machine.SwitchState(LinkStates.LeftWalk);
        }
    }
}
