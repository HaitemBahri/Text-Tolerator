namespace TextTolerator.Core.Rules.ReplacerRules
{
    public class ReplacerRuleValue
    {
        public string ReplaceFrom { get; }
        public string ReplaceBy { get; }
        public CharPosition Position { get; }

        public ReplacerRuleValue(string replaceFrom, string replaceBy, CharPosition position)
        {
            ReplaceFrom = replaceFrom;
            ReplaceBy = replaceBy;
            Position = position;
        }
    }
}
