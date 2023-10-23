namespace TextTolerator.Core.Rules.RulesBases
{
    public class CleanerRuleValue
    {
        public string ReplaceFrom { get; }
        public StringPosition Position { get; }

        public CleanerRuleValue(string replaceFrom, StringPosition position)
        {
            ReplaceFrom = replaceFrom;
            Position = position;
        }
    }
}
