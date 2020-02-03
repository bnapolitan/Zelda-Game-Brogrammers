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

        public AnimatedSprite(SpriteAtlas atlas, Vector2 position, List<Rectangle> sourceRects, float frameTime, IGameObject gameObject = null, Vector2? scale = null)
            : base(atlas, position, new MultipleSource(sourceRects), gameObject, scale)
        {
            this.frameTime = frameTime;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(atlas.Texture, CalculateDestRect(), source.GetSourceRectangle(currentFrame), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (lastFrameChange + frameTime <= gameTime.TotalGameTime.TotalSeconds)
            {
                currentFrame = (currentFrame + 1) % source.GetNumberFrames();
                lastFrameChange = (float) gameTime.TotalGameTime.TotalSeconds;
                SetWidthHeight(currentFrame);
            }
        }
    }
}
