using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.PhoneNumberRules
{
    public class PhoneNumberBracketsPolisherRule : IRule
    {
        protected List<PolisherRuleValue> PolisherRuleValues => new()
        {
            new PolisherRuleValue("(", StringPosition.Start | StringPosition.Mid | StringPosition.End),
            new PolisherRuleValue(")", StringPosition.Start | StringPosition.Mid | StringPosition.End),
        };

        public List<string> ProcessText(string inputText)
        {
            var polisherRule = new PolisherRuleBase();

            return polisherRule.ProcessText(inputText, PolisherRuleValues);
        }
    }
}
