using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project3902
{
    class BackAndForthSprite : AnimatedSprite
    {
        private readonly float speed;
        private readonly float distance;
        private Vector2 relPosition;
        private Vector2 direction;
        private SpriteEffects flip = SpriteEffects.None;

        public BackAndForthSprite(IGameObject gameObject, SpriteAtlas atlas, List<Rectangle> sourceRects, float frameTime, float moveSpeed, float travelDistance, Vector2? scale = null)
            : base(gameObject, atlas, sourceRects, frameTime, scale)
        {
            speed = moveSpeed;
            distance = travelDistance;
            relPosition = Vector2.Zero;
            direction = new Vector2(1, 0);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            relPosition += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (relPosition.X > distance)
            {
                direction *= -1;
                relPosition.X = distance;
                flip = SpriteEffects.FlipHorizontally;
            }
            else if (relPosition.X < -distance)
            {
                direction *= -1;
                relPosition.X = -distance;
                flip = SpriteEffects.None;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = CalculateDestRect();
            dest.X += (int) relPosition.X;
            spriteBatch.Draw(atlas.Texture, dest, source.GetSourceRectangle(currentFrame), Color.White, 0, Vector2.Zero, flip, 0f);
        }
    }
}