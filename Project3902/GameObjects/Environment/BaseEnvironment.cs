using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902.GameObjects.Environment
{
    abstract class BaseEnvironment : IGameObject, IInteractiveEnvironmentObject
    {
        public Collider Collider { get; set; }
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; } = true;

        public BaseEnvironment(Vector2 position)
        {
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }

        public virtual void OnCollide(Collider other)
        {

        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
    }
}
