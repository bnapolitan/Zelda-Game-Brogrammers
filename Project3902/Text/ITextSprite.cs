using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    interface ITextSprite:IDrawable
    {
        string Text { get; set; }
        Vector2 Position { get; set; }
        Color TextColor { get; set; }
        SpriteFont Font { get; set; }
        bool AlignCenter { get; set; }

        void Draw(SpriteBatch spriteBatch);
    }
}
