using TextTolerator.Core.Attributes;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.PhoneNumberRules
{
    [PhoneNumberRule]
    public class PhoneNumberSeparatorPolisherRule : IRule
    {
        protected List<PolisherRuleValue> PolisherRuleValues => new()
        {
            new PolisherRuleValue(" ", StringPosition.Start | StringPosition.Mid | StringPosition.End ),
            new PolisherRuleValue("-", StringPosition.Start | StringPosition.Mid | StringPosition.End ),
        };

        public List<string> ProcessText(string inputText)
        {
            var polisherRuleBase = new PolisherRuleBase();

            return polisherRuleBase.ProcessText(inputText, PolisherRuleValues);
        }
    }
}
