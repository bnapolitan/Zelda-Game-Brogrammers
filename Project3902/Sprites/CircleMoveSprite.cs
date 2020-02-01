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
        private Vector2 center;
        private float radius;
        private float speed;

        public CircleMoveSprite(SpriteAtlas atlas, Vector2 position, Rectangle sourceRect, float circleRadius, float revolveSpeed, Vector2? scale = null)
            : base(atlas, position, new SingleSource(sourceRect), scale)
        {
            radius = circleRadius;
            speed = revolveSpeed;
            center = position;
        }

        public override void Update(GameTime gameTime)
        {
            float x = center.X + (float) Math.Cos(gameTime.TotalGameTime.TotalSeconds * speed) * radius;
            float y = center.Y + (float) Math.Sin(gameTime.TotalGameTime.TotalSeconds * speed) * radius;
            Position = new Vector2(x, y);
        }
    }
}
