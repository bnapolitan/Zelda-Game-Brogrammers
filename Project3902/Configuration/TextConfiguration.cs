using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.Configuration
{
    public static class TextConfiguration
    {
        public static int TextWritingDivisor { get; } = 7;
        public static string OldManText { get; } = "EASTMOST PENNINSULA IS THE SECRET.";
        public static int TextInitialXPosition { get; } = 310;
        public static int XOffsetPerLetter { get; } = 22;
        public static int TextYPosition { get; } = 250;
        public static int FirstLineLength { get; } = 19;
        public static int SecondLineYPosition { get; } = 300;
        public static int SecondLineXOffset { get; } = 17;
    }
}
