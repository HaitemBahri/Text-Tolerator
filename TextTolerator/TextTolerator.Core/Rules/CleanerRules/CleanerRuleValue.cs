namespace TextTolerator.Core.Rules.CleanerRules
{
    public class CleanerRuleValue
    {
        public string ReplaceFrom { get; }
        public CharPosition Position { get; }

        public CleanerRuleValue(string replaceFrom, CharPosition position)
        {
            ReplaceFrom = replaceFrom;
            Position = position;
        }
    }
}
