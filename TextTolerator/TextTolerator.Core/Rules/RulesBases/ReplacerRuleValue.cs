namespace TextTolerator.Core.Rules.RulesBases
{
    public class ReplacerRuleValue
    {
        public string ReplaceFrom { get; }
        public string ReplaceBy { get; }
        public StringPosition Position { get; }

        public ReplacerRuleValue(string replaceFrom, string replaceBy, StringPosition position)
        {
            ReplaceFrom = replaceFrom;
            ReplaceBy = replaceBy;
            Position = position;
        }
    }
}
