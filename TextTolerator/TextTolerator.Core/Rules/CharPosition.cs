using System.Runtime.CompilerServices;

namespace TextTolerator.Core.Rules
{
    [Flags]
    public enum CharPosition
    {
        Start = 1,
        Mid = 2,
        End = 4,
    }

    public static class CharPositionExtensions
    {
        public static bool IsStart(this CharPosition position)
        {
            return (position & CharPosition.Start) == CharPosition.Start;
        }

        public static bool IsMid(this CharPosition position)
        {
            return (position & CharPosition.Mid) == CharPosition.Mid;
        }

        public static bool IsEnd(this CharPosition position)
        {
            return (position & CharPosition.End) == CharPosition.End;
        }
    }
}
