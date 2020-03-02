using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Project3902
{
    class AnimatedSprite : BaseSprite
    {
        private readonly float frameTime;
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
