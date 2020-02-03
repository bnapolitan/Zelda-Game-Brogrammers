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
        private float radius;
        private float speed;

        public CircleMoveSprite(SpriteAtlas atlas, Vector2 position, Rectangle sourceRect, float circleRadius, float revolveSpeed, IGameObject gameObject = null, Vector2? scale = null)
            : base(atlas, position, new SingleSource(sourceRect), gameObject, scale)
        {
            radius = circleRadius;
            speed = revolveSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float x = Position.X + (float) Math.Cos(gameTime.TotalGameTime.TotalSeconds * speed) * radius;
            float y = Position.Y + (float) Math.Sin(gameTime.TotalGameTime.TotalSeconds * speed) * radius;
            Position = new Vector2(x, y);
        }
    }
}
