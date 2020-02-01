using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class SimpleText : ITextSprite
    {
        private Vector2 textSize;
        private string text;

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                textSize = Font.MeasureString(value);
            }
        }
        public Vector2 Position { get; set; }
        public Color TextColor { get; set; }
        public SpriteFont Font { get; set; }
        public bool AlignCenter { get; set; }

        public SimpleText(string text, Vector2 position, Color color, SpriteFont font, bool alignCenter = false)
        {
            Font = font;
            Text = text;
            Position = position;
            TextColor = color;
            AlignCenter = alignCenter;

            textSize = Font.MeasureString(Text);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (AlignCenter)
                spriteBatch.DrawString(Font, Text, new Vector2(Position.X - textSize.X / 2, Position.Y - textSize.Y / 2), TextColor);
            else
                spriteBatch.DrawString(Font, Text, Position, TextColor);
        }
    }
}
