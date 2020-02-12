using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    abstract class BaseLinkItemState : BaseLinkState
    {
        private float itemUseTime = 1.0f;
        private float timeSinceUse = 0;
        protected Vector2 direction;

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
            link.CurrentWeapon.Launch(link.Position, direction);
        }

        protected abstract void EndUse();

        public override void Attack() { }

        public override void MoveDown() { }

        public override void MoveLeft() { }

        public override void MoveRight() { }

        public override void MoveUp() { }

        public override void TakeDamage(float damage)
        {
            link.Health -= damage;
        }

        public override void UseItem() { }
    }
}
