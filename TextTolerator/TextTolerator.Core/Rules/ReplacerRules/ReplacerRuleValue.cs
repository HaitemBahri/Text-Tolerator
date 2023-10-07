namespace TextTolerator.Core.Rules.ReplacerRules
{
    public class ReplacerRuleValue
    {
        public char ReplaceFrom { get; }
        public char ReplaceBy { get; }
        public CharPosition Position { get; }

        public ReplacerRuleValue(char replaceFrom, char replaceBy, CharPosition position)
        {
            ReplaceFrom = replaceFrom;
            ReplaceBy = replaceBy;
            Position = position;
        }
    }
}
