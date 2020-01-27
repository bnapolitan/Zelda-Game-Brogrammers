using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0
{
    class BackAndForthSprite : AnimatedSprite
    {
        private float speed;
        private float distance;
        private Vector2 startPosition;
        private Vector2 direction;
        private SpriteEffects flip = SpriteEffects.None;

        public BackAndForthSprite(SpriteAtlas atlas, Vector2 position, List<Rectangle> sourceRects, float frameTime, float moveSpeed, float travelDistance, Vector2? scale = null)
            : base(atlas, position, sourceRects, frameTime, scale)
        {
            speed = moveSpeed;
            distance = travelDistance;
            startPosition = position;
            direction = new Vector2(1, 0);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Position.X > startPosition.X + distance)
            {
                direction *= -1;
                Position = new Vector2(startPosition.X + distance, Position.Y);
                flip = SpriteEffects.FlipHorizontally;
            }
            else if (Position.X < startPosition.X - distance)
            {
                direction *= -1;
                Position = new Vector2(startPosition.X - distance, Position.Y);
                flip = SpriteEffects.None;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(atlas.Texture, CalculateDestRect(), source.GetSourceRectangle(currentFrame), Color.White, 0, Vector2.Zero, flip, 0f);
        }
    }
}
