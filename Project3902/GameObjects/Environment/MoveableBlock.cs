﻿using Microsoft.Xna.Framework;

namespace Project3902.GameObjects.Environment
{
    class MoveableBlock : BaseEnvironment
    {

        public MoveableBlock(Vector2 position)
            : base(position) { }

        public int MaxFrames { get; internal set; }
        public Vector2 Direction { get; internal set; }
    }
}
