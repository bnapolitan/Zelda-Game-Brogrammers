using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Project3902
{
    class MultipleSource : IAtlasSource
    {
        private readonly List<Rectangle> sourceRects;

        public MultipleSource(List<Rectangle> sourceRects)
        {
            this.sourceRects = sourceRects;
        }

        public Rectangle GetSourceRectangle(int frame = 0)
        {
            return sourceRects[frame];
        }

        public Vector2 GetFrameSize(int frame = 0)
        {
            return new Vector2(sourceRects[frame].Width, sourceRects[frame].Height);
        }

        public int GetNumberFrames()
        {
            return sourceRects.Count;
        }
    }
}
