using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Project3902
{
    class HUDObject : IHUDObject
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool Active { get; set; }

        public HUDObject(Vector2 position)
        {
            Position = position;
            Active = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }


        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);

        }
    }
}
