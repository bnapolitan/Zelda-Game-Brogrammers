using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class SingleSource : IAtlasSource
    {
        private Rectangle sourceRect;
        private Vector2 size;

        public SingleSource(Rectangle sourceRect)
        {
            this.sourceRect = sourceRect;
            size = new Vector2(sourceRect.Width, sourceRect.Height);
        }

        public Rectangle GetSourceRectangle(int frame = 0)
        {
            return sourceRect;
        }

        public Vector2 GetFrameSize(int frame = 0)
        {
            return size;
        }

        public int GetNumberFrames()
        {
            return 1;
        }
    }
}
