using System.Runtime.CompilerServices;

namespace TextTolerator.Core.Rules
{
    [Flags]
    public enum StringPosition
    {
        Start = 1,
        Mid = 2,
        End = 4,
    }

    public static class CharPositionExtensions
    {
        public static bool IsStart(this StringPosition position)
        {
            return (position & StringPosition.Start) == StringPosition.Start;
        }

        public static bool IsMid(this StringPosition position)
        {
            return (position & StringPosition.Mid) == StringPosition.Mid;
        }

        public static bool IsEnd(this StringPosition position)
        {
            return (position & StringPosition.End) == StringPosition.End;
        }
    }
}
