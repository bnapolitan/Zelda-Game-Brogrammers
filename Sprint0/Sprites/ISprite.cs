using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public interface ISprite
    {
        Vector2 Position { get; set; }
        Vector2 Scale { get; set; }
        Texture2D Texture { get; set; }
        bool CenterPivot { get; set; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
