
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.ObjectManagement;

namespace Project3902
{
    class LinkTriforceState : BaseLinkState
    {
        private float stateTimer = 7.8f;
        private IGameObject triforce;

        public LinkTriforceState(Link link, LinkStateMachine machine)
            : base(link, machine)
        {
            Sprite = LinkFactory.Instance.CreateTriforceSprite(link);
            triforce = ItemFactory.Instance.CreateTriforceImage(new Vector2(0, 0));
        }

        public override void Enter()
        {
            base.Enter();
            SoundHandler.Instance.PlaySong("Triforce");
            triforce.Position = link.Position + new Vector2(8, -40);
        }

        public override void Exit()
        {
            base.Exit();
            SoundHandler.Instance.PlaySong("Dungeon");
        }

        public override void Attack()
        {
        }

        public override void MoveDown()
        {
        }

        public override void MoveLeft()
        {
        }

        public override void MoveRight()
        {
        }

        public override void MoveUp()
        {
        }

        public override void Update(GameTime gameTime)
        {
            stateTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (stateTimer <= 0)
            {
                machine.SwitchState(LinkStates.DownWalk);
            }
            triforce.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            triforce.Draw(spriteBatch);
        }

        public override void UseItem()
        {
        }
    }
}
