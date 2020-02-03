using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    class FixedSprite : BaseSprite
    {
        public FixedSprite(SpriteAtlas atlas, Vector2 position, Rectangle sourceRect, IGameObject gameObject = null, Vector2? scale = null)
            : base(atlas, position, new SingleSource(sourceRect), gameObject, scale) { }
    }
}
