using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class NullSprite : ISprite
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public Texture2D Texture { 
            get { }
            set { }
        }
        public bool CenterPivot { get; set; }

        public NullSprite()
        {
            Position = Vector2.Zero;
            Scale = Vector2.Zero;
            CenterPivot = false;
        }

        public void Draw(SpriteBatch spriteBatch) { }

        public void Update(GameTime gameTime) { }
    }
}
