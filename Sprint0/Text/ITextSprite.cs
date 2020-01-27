using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    interface ITextSprite
    {
        string Text { get; set; }
        Vector2 Position { get; set; }
        Color TextColor { get; set; }
        SpriteFont Font { get; set; }
        bool AlignCenter { get; set; }

        void Draw(SpriteBatch spriteBatch);
    }
}
