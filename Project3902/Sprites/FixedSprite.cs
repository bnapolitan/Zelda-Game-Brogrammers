using Microsoft.Xna.Framework;

namespace Project3902
{
    class FixedSprite : BaseSprite
    {
        public FixedSprite(IGameObject gameObject, SpriteAtlas atlas, Rectangle sourceRect, Vector2? scale = null)
            : base(gameObject, atlas, new SingleSource(sourceRect), scale) { }

        public override void Update(GameTime gameTime) { }
    }
}
