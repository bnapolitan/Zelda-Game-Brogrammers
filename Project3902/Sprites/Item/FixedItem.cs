using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project3902;

namespace Project3902
{
    public class FixedItem : ItemSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private ItemReg ItController;
        private Sprint2 game;

        public FixedItem(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = Sprint2.currentFram.Current;
            totalFrames = Rows * Columns;

            ItController = ItemCtl.Instance.ItemRegister(game);

            if (currentFrame == totalFrames)
                currentFrame = 0;
            if (currentFrame == -1)
                currentFrame = totalFrames - 1;
            Sprint2.currentFram.Current = currentFrame;
        }

        public void Update()
        {
            ItController.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(100, 250, width, height);

            //spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            //spriteBatch.End();
        }
    }
}
