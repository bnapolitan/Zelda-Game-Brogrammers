using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project3902
{
    class VariedOriginsSprite : AnimatedSprite
    {
        private readonly List<Vector2> origins;

        public VariedOriginsSprite(IGameObject gameObject, SpriteAtlas atlas, List<Rectangle> sourceRects, List<Vector2> origins, float frameTime, Vector2? scale = null)
            : base(gameObject, atlas, sourceRects, frameTime, scale)
        {
            this.origins = origins;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(atlas.Texture, CalculateDestRect(), source.GetSourceRectangle(currentFrame), Color.White, 0, origins[currentFrame], Flip, 0f);
        }

        public override void DrawTinted(SpriteBatch spriteBatch, Color tint)
        {
            spriteBatch.Draw(atlas.Texture, CalculateDestRect(), source.GetSourceRectangle(currentFrame), tint, 0, origins[currentFrame], Flip, 0f);
        }
    }
}
