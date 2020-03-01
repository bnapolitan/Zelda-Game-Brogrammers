using Microsoft.Xna.Framework;

namespace Project3902
{
    interface IAtlasSource
    {
        Rectangle GetSourceRectangle(int frame = 0);

        Vector2 GetFrameSize(int frame = 0);

        int GetNumberFrames();

    }
}
