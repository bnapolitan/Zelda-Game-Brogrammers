using Microsoft.Xna.Framework;

namespace Project3902
{
    abstract class BaseLinkWalkState : BaseLinkState
    {
        protected Vector2 velocity = Vector2.Zero;

        public BaseLinkWalkState(Link link, LinkStateMachine machine)
            : base(link, machine) { }

        public override void MoveDown()
        {
            machine.SwitchState(LinkStates.DownWalk);
        }
        public override void MoveLeft()
        {
            machine.SwitchState(LinkStates.LeftWalk);
        }
        public override void MoveRight()
        {
            machine.SwitchState(LinkStates.RightWalk);
        }
        public override void MoveUp()
        {
            machine.SwitchState(LinkStates.UpWalk);
        }

        public override void Update(GameTime gameTime)
        {
            if (velocity != Vector2.Zero)
                Sprite.Update(gameTime);

            link.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            velocity = Vector2.Zero;
        }

        public override void TakeDamage(float damage)
        {
            // Ow!
        }

    }
}
