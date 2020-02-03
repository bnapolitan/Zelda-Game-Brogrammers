using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class FixedSprite : BaseSprite
    {
        public FixedSprite(IGameObject gameObject, SpriteAtlas atlas, Vector2 position, Rectangle sourceRect, Vector2? scale = null)
            : base(gameObject, atlas, position, new SingleSource(sourceRect), scale) { }
    }
}
