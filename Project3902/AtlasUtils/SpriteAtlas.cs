using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class SpriteAtlas
    {
        public Texture2D Texture { get; set; }

        public SpriteAtlas(Texture2D texture)
        {
            Texture = texture;
        }

    }
}
