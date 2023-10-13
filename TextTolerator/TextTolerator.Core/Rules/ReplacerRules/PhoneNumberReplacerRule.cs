namespace TextTolerator.Core.Rules.ReplacerRules
{
    public class PhoneNumberReplacerRule : ReplacerRuleBase
    {
        protected override List<ReplacerRuleValue> ReplacerRuleValues => new()
        {
            new ReplacerRuleValue("+", "00", CharPosition.Start),
            new ReplacerRuleValue("00", "+", CharPosition.Start),
        };
    }
}
