using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class FixedSprite : BaseSprite
    {
        public FixedSprite(IGameObject gameObject, SpriteAtlas atlas, Rectangle sourceRect, Vector2? scale = null)
            : base(gameObject, atlas, new SingleSource(sourceRect), scale) { }

        public override void Update(GameTime gameTime)
        {
            /* Does not animate. */
        }
    }
}
