using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace Project3902
{
    class AnimatedSprite : BaseSprite
    {
        protected int currentFrame;
        private float frameTime;
        private float lastFrameChange;

        public new Vector2 Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
                SetWidthHeight(currentFrame);
            }
        }

        public AnimatedSprite(IGameObject gameObject, SpriteAtlas atlas, List<Rectangle> sourceRects, float frameTime, Vector2? scale = null)
            : base(gameObject, atlas, new MultipleSource(sourceRects), scale)
        {
            this.frameTime = frameTime;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(atlas.Texture, CalculateDestRect(), source.GetSourceRectangle(currentFrame), Color.White, 0f, Vector2.Zero, Flip, 0f);
        }

        public override void Update(GameTime gameTime)
        {
            if (lastFrameChange + frameTime <= gameTime.TotalGameTime.TotalSeconds)
            {
                currentFrame = (currentFrame + 1) % source.GetNumberFrames();
                lastFrameChange = (float) gameTime.TotalGameTime.TotalSeconds;
                SetWidthHeight(currentFrame);
            }
        }
    }
}
