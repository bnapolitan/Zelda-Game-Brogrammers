using Microsoft.Xna.Framework;

namespace Project3902
{
    abstract class BaseLinkAttackState : BaseLinkState
    {
        private float timeSinceStart = 0;
        private readonly float attackTime = .45f;
        protected Vector2 direction;

        public BaseLinkAttackState(Link link, LinkStateMachine machine)
            : base(link, machine) { }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);

            timeSinceStart += (float) gameTime.ElapsedGameTime.TotalSeconds;
            if (timeSinceStart >= attackTime)
                EndAttack();
        }

        public override void Enter()
        {
            timeSinceStart = 0;
            (Sprite as AnimatedSprite).ResetAnimation();

            if (link.Health == link.MaxHealth)
            {
                link.SwordProjectile.Launch(link.Position + link.Sprite.Scale * new Vector2(4, 4), direction);
            }
        }

        protected abstract void EndAttack();

        public override void MoveDown() { }
        public override void MoveLeft() { }
        public override void MoveRight() { }
        public override void MoveUp() { }

        public override void Attack() { }

        public override void UseItem() { }
    }
}
