using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Project3902
{
    class ShapeSpriteFactory : IDisposable
    {
        public Texture2D WhiteRect { get; set; }

        public static ShapeSpriteFactory Instance { get; } = new ShapeSpriteFactory();

        private ShapeSpriteFactory() { }

        public void CreateShapeTextures(GraphicsDevice graphics)
        {
            WhiteRect = new Texture2D(graphics, 1, 1);
            WhiteRect.SetData(new[] { Color.White });
        }

        public void Dispose()
        {
            WhiteRect.Dispose();
        }
    }
}
