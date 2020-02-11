using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.Sprites.EnemySprites
{
    class WallmasterSprite : AnimatedSprite
    {
        public WallmasterSprite(IGameObject gameObject, SpriteAtlas atlas, List<Rectangle> sourceRects, float frameTime, Vector2? scale = null)
            : base(gameObject, atlas, sourceRects, frameTime, scale)
        {
        }
    }
}
