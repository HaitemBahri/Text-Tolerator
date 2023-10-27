using TextTolerator.Core.Attributes;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.PhoneNumberRules
{
    [PhoneNumberRule]
    public class PhoneNumberIntCodeReplacerRule : IRule
    {
        protected List<ReplacerRuleValue> ReplacerRuleValues => new()
        {
            new ReplacerRuleValue("+", "00", StringPosition.Start),
            new ReplacerRuleValue("00", "+", StringPosition.Start),
        };

        public List<string> ProcessText(string inputText)
        {
            var replacerRuleBase = new ReplacerRuleBase();

            return replacerRuleBase.ProcessText(inputText, ReplacerRuleValues);
        }
    }
}
