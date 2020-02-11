﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    // If you want to simply draw an image on the screen at a certain position.
    class SimpleSprite : ISprite
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; } = new Vector2(1, 1);
        public Texture2D Texture { get; set; }
        public bool CenterPivot { get; set; } = false;
        public IGameObject GameObject { get; set; }

        public SimpleSprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Update(GameTime gameTime) { /* Does not move or animate. */ }
    }
}
