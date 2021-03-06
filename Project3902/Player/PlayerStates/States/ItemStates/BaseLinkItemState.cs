﻿using Microsoft.Xna.Framework;

namespace Project3902
{
    abstract class BaseLinkItemState : BaseLinkState
    {
        private float itemUseTime = .4f;
        private float timeSinceUse = 0;

        public BaseLinkItemState(Link link, LinkStateMachine machine)
            : base(link, machine) { }

        public override void Update(GameTime gameTime)
        {
            timeSinceUse += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeSinceUse >= itemUseTime)
            {
                EndUse();
            }
        }

        public override void Enter()
        {
            timeSinceUse = 0;
            if(link.CurrentWeapon is ArrowProjectile)
            {
                itemUseTime = .2f;
            }
            else
            {
                itemUseTime = .4f;
            }
            link.CurrentWeapon.Launch(link.Position, link.FacingDirection);
        }

        protected abstract void EndUse();

        public override void Attack() { }

        public override void MoveDown() { }

        public override void MoveLeft() { }

        public override void MoveRight() { }

        public override void MoveUp() { }
        public override void UseItem() { }
    }
}
