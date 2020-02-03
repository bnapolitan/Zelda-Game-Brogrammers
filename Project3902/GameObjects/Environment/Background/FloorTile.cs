using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.GameObjects.Environment
{
    class FloorTile : IInteractiveEnvironmentObject
    {

        public FloorTile(ISprite sprite, Vector2 position)
        {
            this.Sprite = sprite;
            this.Position = position;
        }

        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }

        public void Activate()
        {
        }

        public void Deactivate()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite.Texture, Position, new Rectangle(984, 11, 16, 16), Color.White);
        }
    }
}
