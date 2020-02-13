using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class FlippingSprite : BaseSprite
    {
        private float flipTime;
        private float lastFlipTime;

        public FlippingSprite(IGameObject gameObject, SpriteAtlas atlas, Rectangle sourceRect, float flipTime, Vector2? scale = null)
            : base(gameObject, atlas, new SingleSource(sourceRect), scale)
        {
        
            this.flipTime = flipTime;
            lastFlipTime = 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (lastFlipTime + flipTime <= gameTime.TotalGameTime.TotalSeconds)
            {
                if (Flip == SpriteEffects.None)
                    Flip = SpriteEffects.FlipHorizontally;
                else
                    Flip = SpriteEffects.None;

                lastFlipTime = (float)gameTime.TotalGameTime.TotalSeconds;
            }
        }
    }
}
