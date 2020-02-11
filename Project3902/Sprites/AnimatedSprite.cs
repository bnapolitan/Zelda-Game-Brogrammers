using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace Project3902
{
    class AnimatedSprite : BaseSprite
    {
        private float frameTime;
        private float lastFrameChange;

        public AnimatedSprite(IGameObject gameObject, SpriteAtlas atlas, List<Rectangle> sourceRects, float frameTime, Vector2? scale = null)
            : base(gameObject, atlas, new MultipleSource(sourceRects), scale)
        {
            this.frameTime = frameTime;
            lastFrameChange = 0;
        }


        public override void Update(GameTime gameTime)
        {
            if (lastFrameChange + frameTime <= gameTime.TotalGameTime.TotalSeconds)
            {
                // Store number of frames somewhere instead of accessing it constantly.
                currentFrame = (currentFrame + 1) % source.GetNumberFrames();
                lastFrameChange = (float) gameTime.TotalGameTime.TotalSeconds;
                SetWidthHeight();
            }
        }

        public void ResetAnimation()
        {
            lastFrameChange = 0;
            currentFrame = 0;
        }
    }
}
