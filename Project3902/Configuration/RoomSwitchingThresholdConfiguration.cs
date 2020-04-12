using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.Configuration
{
    public static class RoomSwitchingThresholdConfiguration
    {
        public static int LeftRoomThreshold { get; } = 200;
        public static int RightRoomThreshold { get; } = 700;
        public static int TopRoomThreshold { get; } = 200;
        public static int BottomRoomThreshold { get; } = 500;
    }
}
