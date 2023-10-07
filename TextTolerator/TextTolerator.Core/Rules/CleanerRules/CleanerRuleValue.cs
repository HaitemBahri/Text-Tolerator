
using TextTolerator.Core.Rules.ReplacerRules;

namespace TextTolerator.Core.Rules.CleanerRules
{
    public class CleanerRuleValue
    {
        public char ReplaceFrom { get; }
        public CharPosition Position { get; }

        public CleanerRuleValue(char replaceFrom, CharPosition position)
        {
            ReplaceFrom = replaceFrom;
            Position = position;
        }
    }
}
