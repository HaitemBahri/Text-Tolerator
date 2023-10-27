namespace TextTolerator.Core.Rules.RulesBases
{
    public class PolisherRuleValue
    {
        public string ReplaceFrom { get; }
        public StringPosition Position { get; }

        public PolisherRuleValue(string replaceFrom, StringPosition position)
        {
            ReplaceFrom = replaceFrom;
            Position = position;
        }
    }
}
