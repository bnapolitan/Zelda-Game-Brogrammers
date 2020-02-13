using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    abstract class BaseLinkAttackState : BaseLinkState
    {
        private float timeSinceStart = 0;
        private float attackTime = .45f; // Equal to the attack animation time.
        protected Vector2 direction;

        public BaseLinkAttackState(Link link, LinkStateMachine machine)
            : base(link, machine) { }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            timeSinceStart += (float) gameTime.ElapsedGameTime.TotalSeconds;
            if (timeSinceStart >= attackTime)
                EndAttack();
        }

        public override void Enter()
        {
            timeSinceStart = 0;
            (stateSprite as AnimatedSprite).ResetAnimation();

            if (link.Health == link.MaxHealth)
            {
                link.SwordProjectile.Launch(link.Position + link.Sprite.Scale * new Vector2(4, 4), direction);
            }
        }

        protected abstract void EndAttack();

        // Does not move while attacking.
        public override void MoveDown() { }
        public override void MoveLeft() { }
        public override void MoveRight() { }
        public override void MoveUp() { }

        public override void Attack()
        {
            // Already attacking.
        }

        public override void UseItem()
        {
            // Busy attacking.
        }

        public override void TakeDamage(float damage)
        {
            link.Health -= damage;
        }
    }
}
