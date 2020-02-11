using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project3902.GameObjects.Enemies_and_NPCs;

namespace Project3902.Sprites.EnemySprites
{
    class GelSprite : AnimatedSprite
    {
        public GelSprite(IGameObject gameObject, SpriteAtlas atlas, List<Rectangle> sourceRects, float frameTime, Vector2? scale = null)
            : base(gameObject, atlas, sourceRects, frameTime, scale)
        {

        }
    }
}
