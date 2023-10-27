using TextTolerator.Core.Attributes;
using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.ArabicRules
{
    [ArabicRule]
    public class ArabicAlifLamCleanerTogglerRule : IRule
    {
        protected List<CleanerTogglerRuleValue> CleanerTogglerRuleValues => new()
        {
            new CleanerTogglerRuleValue("ال", StringPosition.Start),
        };

        public List<string> ProcessText(string inputText)
        {
            var cleanerTogglerRule = new CleanerTogglerRuleBase();

            return cleanerTogglerRule.ProcessText(inputText, CleanerTogglerRuleValues);
        }
    }
}
