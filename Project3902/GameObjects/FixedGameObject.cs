using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class FixedGameObject : IGameObject
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; } = true;

        public FixedGameObject(Vector2 position)
        {
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Look for a better solution than having the game object call sprite's draw method...
            Sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
    }
}
