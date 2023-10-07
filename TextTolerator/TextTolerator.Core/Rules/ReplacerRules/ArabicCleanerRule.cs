
using TextTolerator.Core.Rules.CleanerRules;

namespace TextTolerator.Core.Rules.ReplacerRules
{
    public class ArabicCleanerRule : CleanerRule
    {
        protected override List<CleanerRuleValue> CleanerRuleValues =>
            new List<CleanerRuleValue>()
            {
                new CleanerRuleValue('َ', CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new CleanerRuleValue('ً', CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new CleanerRuleValue('ُ', CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new CleanerRuleValue('ٌ', CharPosition.Start | CharPosition.Mid | CharPosition.End),
                new CleanerRuleValue('ّ', CharPosition.Start | CharPosition.Mid | CharPosition.End),



            };
    }
}
