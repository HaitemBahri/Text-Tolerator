using TextTolerator.Core.Attributes;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.EnglishRules
{
    [EnglishRule]
    public class EnglishINGReplacerRule : IRule
    {
        protected List<ReplacerRuleValue> ReplacerRuleValues => new()
        {
            new ReplacerRuleValue("ing", "in'", StringPosition.End),
            new ReplacerRuleValue("ING", "IN'", StringPosition.End),

            new ReplacerRuleValue("in'", "ing", StringPosition.End),
            new ReplacerRuleValue("IN'", "ING", StringPosition.End),
        };

        public List<string> ProcessText(string inputText)
        {
            var replacerRuleBase = new ReplacerRuleBase();

            return replacerRuleBase.ProcessText(inputText, ReplacerRuleValues);
        }
    }
}
