using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    interface IAtlasSource
    {
        Rectangle GetSourceRectangle(int frame = 0);

        Vector2 GetFrameSize(int frame = 0);

        int GetNumberFrames();

    }
}
