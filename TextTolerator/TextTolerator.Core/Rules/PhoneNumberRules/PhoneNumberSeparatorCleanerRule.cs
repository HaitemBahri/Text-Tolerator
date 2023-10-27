using TextTolerator.Core.Rules.RulesBases;

namespace TextTolerator.Core.Rules.PhoneNumberRules
{
    public class PhoneNumberSeparatorCleanerRule : IRule
    {
        protected List<CleanerRuleValue> CleanerRuleValues => new()
        {
            new CleanerRuleValue(" ", StringPosition.Start | StringPosition.Mid | StringPosition.End ),
            new CleanerRuleValue("-", StringPosition.Start | StringPosition.Mid | StringPosition.End ),
        };

        public List<string> ProcessText(string inputText)
        {
            var cleanerRuleBase = new CleanerRuleBase();

            return cleanerRuleBase.ProcessText(inputText, CleanerRuleValues);
        }
    }
}
