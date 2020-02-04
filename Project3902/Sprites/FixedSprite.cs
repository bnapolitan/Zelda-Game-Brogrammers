using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class FixedSprite : BaseSprite
    {
        public FixedSprite(SpriteAtlas atlas, Rectangle sourceRect, Vector2? scale = null)
            : base(atlas, new SingleSource(sourceRect), scale) { }

        public override void Update(GameTime gameTime)
        {
            /* Does not animate. */
        }
    }
}
