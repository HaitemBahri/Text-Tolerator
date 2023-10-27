using TextTolerator.Core.Attributes;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.ArabicRules
{
    [ArabicRule]
    public class ArabicAccentPolisherRule : IRule
    {
        private readonly List<PolisherRuleValue> PolisherRuleValues = new List<PolisherRuleValue>()
        {
                new PolisherRuleValue("َ", StringPosition.Start | StringPosition.Mid | StringPosition.End),
                new PolisherRuleValue("ً", StringPosition.Start | StringPosition.Mid | StringPosition.End),

                new PolisherRuleValue("ُ", StringPosition.Start | StringPosition.Mid | StringPosition.End),
                new PolisherRuleValue("ٌ", StringPosition.Start | StringPosition.Mid | StringPosition.End),

                new PolisherRuleValue("ِ", StringPosition.Start | StringPosition.Mid | StringPosition.End),
                new PolisherRuleValue("ٍ", StringPosition.Start | StringPosition.Mid | StringPosition.End),

                new PolisherRuleValue("ّ", StringPosition.Start | StringPosition.Mid | StringPosition.End),
                new PolisherRuleValue("ْ", StringPosition.Start | StringPosition.Mid | StringPosition.End),

                new PolisherRuleValue("ـ", StringPosition.Start | StringPosition.Mid | StringPosition.End),
        };

        public List<string> ProcessText(string inputText)
        {
            var polisherRule = new PolisherRuleBase();

            return polisherRule.ProcessText(inputText, PolisherRuleValues);
        }
    }
}
