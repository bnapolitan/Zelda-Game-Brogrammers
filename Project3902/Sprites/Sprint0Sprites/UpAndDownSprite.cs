using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project3902
{
    class UpAndDownSprite : AnimatedSprite
    {
        private float speed;
        private float distance;
        private float maxFrame;
        private float frameNow;
        private Vector2 relPosition;
        private Vector2 direction;
        private SpriteEffects flip = SpriteEffects.None;

        public UpAndDownSprite(IGameObject gameObject, SpriteAtlas atlas, List<Rectangle> sourceRects, float frameTime, float moveSpeed, float travelDistance, Vector2? scale = null)
            : base(gameObject, atlas, sourceRects, frameTime, scale)
        {
            speed = moveSpeed;
            distance = travelDistance;
            relPosition = Vector2.Zero;
            direction = new Vector2(0, 1);
            frameNow = 0;
            maxFrame = frameTime;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            relPosition += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameNow++;
            if (frameNow == maxFrame)
            {
                if (flip == SpriteEffects.FlipHorizontally)
                {
                    flip = SpriteEffects.None;
                }
                else
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
                frameNow = 0;
            }
            if (relPosition.Y > distance)
            {
                relPosition.Y = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = CalculateDestRect();
            dest.Y += (int) relPosition.Y;
            spriteBatch.Draw(atlas.Texture, dest, source.GetSourceRectangle(currentFrame), Color.White, 0, Vector2.Zero, flip, 0f);
        }
    }
}