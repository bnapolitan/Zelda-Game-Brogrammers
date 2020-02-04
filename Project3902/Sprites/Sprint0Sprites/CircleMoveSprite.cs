using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class CircleMoveSprite : BaseSprite
    {
        private Vector2 offset;
        private float radius;
        private float speed;

        public CircleMoveSprite(IGameObject gameObject, SpriteAtlas atlas, Rectangle sourceRect, float circleRadius, float revolveSpeed, Vector2? scale = null)
            : base(gameObject, atlas, new SingleSource(sourceRect), scale)
        {
            offset = Vector2.Zero;
            radius = circleRadius;
            speed = revolveSpeed;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dest = CalculateDestRect();
            dest.X += (int) offset.X;
            dest.Y += (int) offset.Y;
            spriteBatch.Draw(Texture, dest, source.GetSourceRectangle(), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            offset.X = (float) Math.Cos(gameTime.TotalGameTime.TotalSeconds * speed) * radius;
            offset.Y = (float) Math.Sin(gameTime.TotalGameTime.TotalSeconds * speed) * radius;
        }
    }
}